using MatrixLibrary.Matrices;
using NUnit.Framework;
using System;

namespace MatrixLibrary.Tests
{
    public class MatrixTests
    {
        private readonly int[,] resultSquaredSymmetric = new int[,] { { 2, 0, 2, 7 }, { 0, 3, 0, 6 }, { 2, 0, 4, 0 }, { 0, 5, 0, 5 } };

        private readonly int[,] resultSquaredDiagonal = new int[,] { { 2, 0, 0, 7 }, { 0, 4, 0, 2 }, { 0, 0, 6, 0 }, { 0, 1, 0, 8 } };

        private readonly int[,] resultSymmetricDiagonal = new int[,] { { 2, 0, 2, 0 }, { 0, 3, 0, 4 }, { 2, 0, 4, 0 }, { 0, 4, 0, 5 } };

        private readonly int[,] squared = new int[,] { { 1, 0, 0, 7 }, { 0, 2, 0, 2 }, { 0, 0, 3, 0 }, { 0, 1, 0, 4 } };

        private readonly int[,] symmetric = new int[,] { { 1, 0, 2, 0 }, { 0, 1, 0, 4 }, { 2, 0, 1, 0 }, { 0, 4, 0, 1 } };

        private readonly int[,] diagonal = new int[,] { { 1, 0, 0, 0 }, { 0, 2, 0, 0 }, { 0, 0, 3, 0 }, { 0, 0, 0, 4 } };

        private readonly int[,] symmetricFail = new int[,] { { 1, 0, 2 }, { 0, 1, 0 }, { 2, 0, 1 } };

        private readonly string[,] symmetricString = new string[,] { { "1", "0", "3" }, { "0", "2", "0" }, { "3", "4", "3" } };

        [Test]
        public void AddMatrixTests()
        {
            Assert.AreEqual(new SquareMatrix<int>(resultSquaredSymmetric), new SquareMatrix<int>(squared).Add(new SymmetricMatrix<int>(symmetric)));
            Assert.AreEqual(new SquareMatrix<int>(resultSquaredDiagonal), new SquareMatrix<int>(squared).Add(new DiagonalMatrix<int>(diagonal)));
            Assert.AreEqual(new SymmetricMatrix<int>(resultSymmetricDiagonal), new SymmetricMatrix<int>(symmetric).Add(new DiagonalMatrix<int>(diagonal)));
        }

        [Test]
        public void FailAddMatrixTests()
        {
            Assert.Throws<InvalidOperationException>(() => new SymmetricMatrix<int>(symmetric).Add(new SymmetricMatrix<int>(symmetricFail)));
        }

        [Test]
        public void MatrixFailTests()
        {
            Matrix<int> matrixInt;
            Matrix<string> matrixString;
            Assert.Throws<ArgumentException>(() => matrixString = new SymmetricMatrix<string>(symmetricString));
            Assert.Throws<ArgumentException>(() => matrixInt = new DiagonalMatrix<int>(symmetric));
        }
    }
}