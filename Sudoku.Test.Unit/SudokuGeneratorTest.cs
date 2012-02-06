using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Models;
using Sudoku.Services;

namespace Sudoku.Test.Unit
{
    [TestClass]
    public class SudokuGeneratorTest
    {
        #region Fields

        private GameBoard _gameBoard;
        private SudokuGenerator _sudokuGenerator;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void AllBoxesHaveEachNumberExactlyOnce()
        {
            for (int i = 0; i < 9; i++)
            {
                var box = _gameBoard.GetBox(i).ToList();

                AssertEachNumberIsOnlyContainedOnce(box);
            }
        }

        [TestMethod]
        public void AllColumnsHaveEachNumberExactlyOnce()
        {
            for (int i = 0; i < 9; i++)
            {
                var column = _gameBoard.GetColumn(i).ToList();

                AssertEachNumberIsOnlyContainedOnce(column);
            }
        }

        [TestMethod]
        public void AllRowsHaveEachNumberExactlyOnce()
        {
            for (int i = 0; i < 9; i++)
            {
                var row = _gameBoard.GetRow(i).ToList();

                AssertEachNumberIsOnlyContainedOnce(row);
            }
        }

        [TestMethod]
        public void GameBoardHasEachNumber9Times()
        {
            for (int i = 1; i <= 9; i++)
            {
                Assert.AreEqual(9, _gameBoard.Fields.Count(p => p == i));
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            _sudokuGenerator = new SudokuGenerator();
            _gameBoard = _sudokuGenerator.GeneratePuzzle();
        }

        #endregion Public Methods

        #region Private Static Methods

        private static void AssertEachNumberIsOnlyContainedOnce(List<int> numbers)
        {
            for (var i = 1; i <= 9; i++)
            {
                Assert.AreEqual(1, numbers.Count(p => p == i));
            }
        }

        #endregion Private Static Methods
    }
}