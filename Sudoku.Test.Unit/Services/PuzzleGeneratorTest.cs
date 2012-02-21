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
                    8, 2, 4, 9, 5, 3, 6, 7, 1,
                    6, 3, 5, 8, 1, 7, 9, 2, 4,
                    7, 1, 9, 6, 2, 4, 8, 5, 3,
                    5, 8, 7, 2, 9, 1, 3, 4, 6,
                    1, 4, 2, 7, 3, 6, 5, 8, 9,
                    3, 9, 6, 4, 8, 5, 2, 1, 7,
                    2, 6, 1, 5, 4, 9, 7, 3, 8,
                    4, 7, 8, 3, 6, 2, 1, 9, 5,
                    9, 5, 3, 1, 7, 8, 4, 6, 2
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