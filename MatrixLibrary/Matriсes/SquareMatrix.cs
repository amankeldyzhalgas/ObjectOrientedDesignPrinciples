using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Matrices
{
    /// <summary>
    /// Квадратная матрица.
    /// </summary>
    /// <typeparam name="T">Тип элементов, из которых состоит матрица.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixArray;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="array">Массив.</param>
        public SquareMatrix(T[,] array) : base(array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array) + " имеет значение null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " пустой");
            }

            Size = array.GetUpperBound(0) + 1; ;
            this.matrixArray = new T[array.Length];
            int k = 0;

            foreach (T i in array)
            {
                this.matrixArray[k++] = i;
            }
        }

        protected override T GetElement(int row, int column)
        {
            return matrixArray[(row * Size) + column];
        }

        protected override void SetElement(int row, int column, T value)
        {
            matrixArray[(row * Size) + column] = value;
        }
    }
}
