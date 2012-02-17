using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.ViewModels.Factories;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameVMFactoryTest
    {
        #region Fields

        private Mock<IGameBoardVMFactory> _gameBoardVMFactory;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void InstanceCanBeCreated()
        {
            _gameBoardVMFactory = new Mock<IGameBoardVMFactory>();
            var factory = new GameVMFactory(_gameBoardVMFactory.Object);

            var gameBoardVM = factory.CreateInstance(Difficulty.Easy);

            Assert.IsNotNull(gameBoardVM);
        }

        #endregion Public Methods
    }
}