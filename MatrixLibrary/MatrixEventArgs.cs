using System;

namespace MatrixLibrary
{
    public class MatrixEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Индекс строки.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Индекс столбца.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Предыдущее значение.
        /// </summary>
        public T PrevValue { get; set; }

        /// <summary>
        /// Новое значение.
        /// </summary>
        public T NewValue { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="row">Индекс строки.</param>
        /// <param name="column">Индекс столбца.</param>
        /// <param name="prevValue">Предыдущее значение.</param>
        /// <param name="newValue">Новое значение.</param>
        public MatrixEventArgs(int row, int column, T prevValue, T newValue)
        {
            this.Row = row;
            this.Column = column;
            this.PrevValue = prevValue;
            this.NewValue = newValue;
        }
    }
}
