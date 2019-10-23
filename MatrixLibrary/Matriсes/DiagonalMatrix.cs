using System;

namespace MatrixLibrary.Matrices
{
    /// <summary>
    /// Диагональная матрица.
    /// </summary>
    /// <typeparam name="T">Тип элементов, из которых состоит матрица.</typeparam>
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixArray;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="array">Массив.</param>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array) + " имеет значение null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " пустой");
            }

            int row = array.GetUpperBound(0) + 1;
            int column = array.Length / (array.GetUpperBound(0) + 1);

            if (row != column)
            {
                throw new ArgumentException($"Не удается сгенерировать матрицу из {array}.", nameof(array));
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = i + 1; j < row; j++)
                {
                    if (!Equals(default(T), array[i, j]) || !Equals(default(T), array[j, i]))
                    {
                        throw new ArgumentException($"Не удается сгенерировать матрицу из {array}.", nameof(array));
                    }
                }
            }

            Size = row;
            this.matrixArray = new T[Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        this.matrixArray[i] = array[i, j];
                    }
                }
            }
        }

        protected override T GetElement(int row, int column)
        {
            if (row != column)
            {
                return default;
            }
            return matrixArray[row];
        }

        protected override void SetElement(int row, int column, T value)
        {
            if (row != column)
            {
                throw new InvalidOperationException("Недопустимые индексы. Индекс строки должен быть равен индексу столбца для диагональной матрицы.");
            }
            matrixArray[row] = value;
        }
    }
}
