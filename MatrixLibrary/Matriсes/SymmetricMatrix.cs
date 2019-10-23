using System;

namespace MatrixLibrary.Matrices
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Тип элементов, из которых состоит матрица.</typeparam>
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixArray;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="array">Массив.</param>
        public SymmetricMatrix(T[,] array) : base(array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array) + " имеет значение null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " пустой");
            }

            Size = array.GetUpperBound(0) + 1;
            this.matrixArray = new T[(Size + array.Length) / 2];
            for (int i = 0, k = 0; i < Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (!Equals(array[i, j], array[j, i]))
                    {
                        throw new ArgumentException($"Не удается сгенерировать матрицу из {array}.", nameof(array));
                    }

                    this.matrixArray[k++] = array[i, j];
                }
            }
        }

        protected override T GetElement(int row, int column)
        {
            if (column >row)
            {
                return matrixArray[GetIndex(column, row)];
            }
            else
            {
                return matrixArray[GetIndex(row, column)];
            }
        }

        protected override void SetElement(int row, int column, T value)
        {
            if (column > row)
            {
                matrixArray[GetIndex(column, row)] = value;
            }
            else
            {
                matrixArray[GetIndex(row, column)] = value;
            }
        }

        private int GetIndex(int row, int column)
        {
            int index = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if((row ==i) && (column ==j))
                    {
                        return index;
                    }
                    index++;
                }
            }
            return -1;
        }
    }
}
