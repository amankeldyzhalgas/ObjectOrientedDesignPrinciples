using MatrixLibrary;
using MatrixLibrary.Matrices;
using System;

namespace MatrixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array =
            {
                {2, 4, 6 },
                {8, 10, 12 },
                {14, 16, 18 }
            };
            SquareMatrix<int> matrix = new SquareMatrix<int>(array);
            matrix.ChangeInMatrix += MyEvent;
            matrix[0, 0] = 1;
            matrix.ChangeInMatrix -= MyEvent;
            matrix[0, 0] = 2;
            matrix.ChangeInMatrix += MyEvent;
            matrix[0, 0] = 3;
            Console.ReadKey();
        }

        static void MyEvent(object sender, MatrixEventArgs<int> e)
        {
            Console.WriteLine($"Элемент  matrix[{e.Row},{e.Column}] был изменен с {e.PrevValue} на {e.NewValue}.");
        }
    }
}
