using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.ViewModels.Factories;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.Test.Unit.ViewModels.Factories
{
    [TestClass]
    public class GameVMFactoryTest
    {
        #region Fields

        private Mock<IGameBoardVMFactory> _gameBoardVMFactory;
        private Mock<IToolVMFactory> _toolVMFactory;

        #endregion Fields

        #region Public Methods

        [TestInitialize]
        public void Initialize()
        {
            _gameBoardVMFactory = new Mock<IGameBoardVMFactory>();
            _toolVMFactory = new Mock<IToolVMFactory>();
        }

        [TestMethod]
        public void InstanceCanBeCreated()
        {
            _toolVMFactory.Setup(p => p.CreateTools(It.IsAny<IGameBoardVM>())).Returns(new List<IToolVM>());
            var factory = new GameVMFactory(_gameBoardVMFactory.Object, _toolVMFactory.Object);

            var gameBoardVM = factory.CreateInstance(Difficulty.Easy);

            Assert.IsNotNull(gameBoardVM);
        }

        #endregion Public Methods
    }
}