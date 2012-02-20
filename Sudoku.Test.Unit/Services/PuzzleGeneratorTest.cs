using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Models;
using Sudoku.Services;

namespace Sudoku.Test.Unit.Services
{
    [TestClass]
    public class PuzzleGeneratorTest
    {
        #region Fields

        private GameBoard _gameBoard;
        private PuzzleGenerator _generator;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void EasyPuzzleContains40Numbers()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Easy, 40);
        }

        [TestMethod]
        public void ExtremePuzzleContains17Numbers()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Extreme, 17);
        }

        [TestMethod]
        public void HardPuzzleContains26Numbers()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Hard, 26);
        }

        [TestInitialize]
        public void Initialize()
        {
            var fields = new[]
                {
                    9, 8, 2, 3, 7, 6, 5, 1, 4,
                    3, 1, 5, 9, 8, 4, 7, 2, 6,
                    7, 4, 6, 1, 2, 5, 8, 3, 9,
                    8, 2, 9, 7, 6, 3, 1, 4, 5,
                    1, 5, 3, 8, 4, 9, 2, 6, 7,
                    4, 9, 8, 2, 1, 7, 6, 5, 3,
                    2, 6, 4, 5, 9, 8, 3, 7, 1,
                    5, 7, 1, 6, 3, 2, 4, 9, 8,
                    6, 3, 7, 4, 5, 1, 9, 8, 2
                };

            _gameBoard = new GameBoard(fields);

            _generator = new PuzzleGenerator();
        }

        [TestMethod]
        public void MediumPuzzleContains30Numbers()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Medium, 30);
        }

        [TestMethod]
        public void VeryEasyPuzzleContains60Numbers()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.VeryEasy, 60);
        }

        #endregion Public Methods

        #region Private Methods

        private void AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty difficulty, int numberOfFields)
        {
            _generator.GeneratePuzzle(_gameBoard, difficulty);

            Assert.AreEqual(numberOfFields, _gameBoard.Fields.Count(p => p > 0));
        }

        #endregion Private Methods
    }
}