using MatrixLibrary.Matrices;
using System;
using System.Linq.Expressions;

namespace MatrixLibrary
{
    /// <summary>
    /// Добавление возможности для операции сложения двух матриц
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Сложения двух матриц любого вида.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix">Матрица.</param>
        /// <param name="adding">Добавляемая матрица.</param>
        /// <returns>Матрица.</returns>
        public static Matrix<T> Add<T>(this Matrix<T> matrix, Matrix<T> adding)
        {
            if (matrix is null || adding is null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} и {nameof(adding)} не может быть null");
            }

            if (matrix.Size != adding.Size)
            {
                throw new InvalidOperationException($"Не возможно добавить \n{matrix} \n на \n{adding}: матрицы имеют разные размеры.");
            }

            T[,] array = new T[matrix.Size, adding.Size];
            for (int i = 0; i < adding.Size; i++)
            {
                for (int j = 0; j < adding.Size; j++)
                {
                    array[i, j] = AddFunc(matrix[i, j], adding[i, j]);
                }
            }

            if (matrix.GetType() == typeof(SymmetricMatrix<T>) || adding.GetType() == typeof(SymmetricMatrix<T>))
            {
                if (matrix.GetType() != typeof(SquareMatrix<T>) && adding.GetType() != typeof(SquareMatrix<T>))
                {
                    return new SymmetricMatrix<T>(array);
                }
            }

            if (matrix.GetType() == typeof(DiagonalMatrix<T>) && adding.GetType() == typeof(DiagonalMatrix<T>))
            {
                return new DiagonalMatrix<T>(array);
            }

            return new SquareMatrix<T>(array);
        }

        private static T AddFunc<T>(T matrix, T adding)
        {
            ParameterExpression paramMatrix = Expression.Parameter(typeof(T), "matrix");
            ParameterExpression paramAdding = Expression.Parameter(typeof(T), "adding");

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(Expression.Add(paramMatrix, paramAdding), paramMatrix, paramAdding).Compile();

            return add(matrix, adding);
        }
    }
}
