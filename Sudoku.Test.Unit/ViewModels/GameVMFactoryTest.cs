using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Factories;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameVMFactoryTest
    {
        private Mock<IGameBoardVMFactory> _gameBoardVMFactory;

        [TestMethod]
        public void InstanceCanBeCreated()
        {
            _gameBoardVMFactory = new Mock<IGameBoardVMFactory>();
            var factory = new GameVMFactory(_gameBoardVMFactory.Object);

            var gameBoardVM = factory.CreateInstance(Difficulty.Easy);

            Assert.IsNotNull(gameBoardVM);
        }
    }
}
