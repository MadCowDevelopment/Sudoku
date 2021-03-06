﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Factories;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.Test.Unit.ViewModels.Factories
{
    [TestClass]
    public class ToolVMFactoryTest
    {
        #region Fields

        private Mock<IGameBoardVM> _gameBoardVMMock;
        private ToolVMFactory _toolVMFactory;

        #endregion Fields

        #region Public Methods

        [TestInitialize]
        public void Initialize()
        {
            _gameBoardVMMock = new Mock<IGameBoardVM>();
            _toolVMFactory = new ToolVMFactory();
        }

        [TestMethod]
        public void ToolFactoryShouldCreateThreeTools()
        {
            var tools = _toolVMFactory.CreateTools(_gameBoardVMMock.Object);

            Assert.AreEqual(3, tools.Count);
        }

        #endregion Public Methods
    }
}