using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Models;
using Sudoku.Services;

namespace Sudoku.Test.Unit.Services
{
    [TestClass]
    public class PuzzleGeneratorTest
    {
        #region Fields

        private IGameBoard _gameBoard;

        private PuzzleGenerator _generator;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void GeneratingEasyPuzzleHasEasyDiffulty()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Easy);
        }

        [TestMethod]
        public void GeneratingExtremePuzzleHasExtremeDiffulty()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Extreme);
        }

        [TestMethod]
        public void GeneratingHardPuzzleHasHardDiffulty()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Hard);
        }

        [TestInitialize]
        public void Initialize()
        {
            _generator = new PuzzleGenerator();
        }

        [TestMethod]
        public void GeneratingMediumPuzzleHasMediumDiffulty()
        {
            AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty.Medium);
        }

        #endregion Public Methods

        #region Private Methods

        private void AssertPuzzleWithDifficultyHasSpecificNumberOfFields(Difficulty difficulty)
        {
            _gameBoard = _generator.GeneratePuzzle(difficulty);

            Assert.AreEqual(difficulty, _gameBoard.Difficulty);
        }

        #endregion Private Methods
    }
}