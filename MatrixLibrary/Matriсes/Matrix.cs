using System;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLibrary.Matrices
{
    /// <summary>
    /// Содержит базовые элементы любой квадратной матрицы.
    /// </summary>
    /// <typeparam name="T">Тип элементов, из которых состоит матрица.</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        /// <summary>
        /// Размер квадратной матрицы.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Выполняется, когда элементы были изменены в матрице.
        /// </summary>
        public event EventHandler<MatrixEventArgs<T>> ChangeInMatrix = delegate { };

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="array">Массив.</param>
        public Matrix(T[,] array)
        {
            int row = array.GetUpperBound(0) + 1;
            int colomn = array.Length / (array.GetUpperBound(0) + 1);
            if (row != colomn)
            {
                throw new ArgumentException($"Не удается сгенерировать матрицу из {array}.", nameof(array));
            }
        }


        /// <summary>
        ///  Возвращает или задает элемент в матрице по указанному индексу.
        /// </summary>
        /// <param name="row">Индекс строки.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <returns>Элемент по указанному индексу.</returns>
        public virtual T this[int row, int column]
        {
            get
            {
                if (row >= Size || column >= Size || row < 0 || column < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return GetElement(row, column);
            }
            set
            {
                if (row >= Size || column >= Size || row < 0 || column < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                var prevValue = GetElement(row, column);
                SetElement(row, column, value);
                OnChangeInMatrix(new MatrixEventArgs<T>(row, column, prevValue, value));
            }
        }

        /// <summary>
        /// Возвращает элемент в матрице по указанному индексу.
        /// </summary>
        /// <param name="row">Индекс строки.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <returns>Элемент по указанному индексу.</returns>
        protected abstract T GetElement(int row, int column);

        /// <summary>
        /// Задает элемент в матрице по указанным индексам строк и столбцов.
        /// </summary>
        /// <param name="row">Индекс строки.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <param name="value">Значение.</param>
        protected abstract void SetElement(int row, int column, T value);

        /// <summary>
        /// Вызывает событие <see cref="E:ChangeInMatrix" />.
        /// </summary>
        /// <param name="eventArgs">Экземпляр, содержащий данные события.</param>
        protected virtual void OnChangeInMatrix(MatrixEventArgs<T> eventArgs)
        {
            ChangeInMatrix?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Возвращает перечислитель, который выполняет итерацию по коллекции.
        /// </summary>
        /// <returns>
        /// Перечислитель, который можно использовать для итерации по коллекции.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        /// <summary>
        /// Возвращает перечислитель, который выполняет итерацию по коллекции.
        /// </summary>
        /// <returns>
        /// Объект, который можно использовать для итерации по коллекции.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
