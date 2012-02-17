using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.Services;
using Sudoku.ViewModels.Factories;

namespace Sudoku.Test.Unit.ViewModels.Factories
{
    [TestClass]
    public class GameBoardVMFactoryTest
    {
        #region Public Methods

        [TestMethod]
        public void InstanceCanBeCreated()
        {
            var sudokuGeneratorMock = new Mock<ISudokuGenerator>();
            sudokuGeneratorMock.Setup(p => p.GeneratePuzzle()).Returns(new GameBoard());
            var puzzleGeneratorMock = new Mock<IPuzzleGenerator>();
            var factory = new GameBoardVMFactory(sudokuGeneratorMock.Object, puzzleGeneratorMock.Object);

            var gameBoardVM = factory.CreateInstance(Difficulty.Easy);

            Assert.IsNotNull(gameBoardVM);
        }

        #endregion Public Methods
    }
}