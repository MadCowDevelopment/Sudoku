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
            var gameBoard = new GameBoard();
            gameBoard.Fields[0] = 1;
            var puzzleGeneratorMock = new Mock<IPuzzleGenerator>();
            puzzleGeneratorMock.Setup(p => p.GeneratePuzzle(Difficulty.Easy)).Returns(gameBoard);
            var factory = new GameBoardVMFactory(puzzleGeneratorMock.Object);

            var gameBoardVM = factory.CreateInstance(Difficulty.Easy);

            Assert.IsNotNull(gameBoardVM);
        }

        #endregion Public Methods
    }
}