﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class MainWindowVMTest
    {
        #region Fields

        private Mock<IGameVM> _gameVM;
        private Mock<IGameVMFactory> _gameVMFactory;
        private IMainWindowVM _mainWindowVM;
        private Mock<IMenuVM> _menuVMMock;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void ContentPropertyRaisesPropertyChanged()
        {
            _mainWindowVM.RaisesPropertyChanged(p => p.Content).When(p => p.Content = null);
        }

        [TestInitialize]
        public void Initialize()
        {
            _menuVMMock = new Mock<IMenuVM>();
            _gameVM = new Mock<IGameVM>();
            _gameVMFactory = new Mock<IGameVMFactory>();

            _mainWindowVM = new MainWindowVM(_menuVMMock.Object, _gameVMFactory.Object);
        }

        [TestMethod]
        public void WhenNewGameIsStartedTheContentIsSetToAGameVM()
        {
            _gameVMFactory.Setup(p => p.CreateInstance(Difficulty.Easy)).Returns(_gameVM.Object);
            _menuVMMock.Raise(p => p.StartGameRequested += null, new StartGameEventArgs(Difficulty.Easy));

            Assert.IsTrue(_mainWindowVM.Content is IGameVM);
        }

        #endregion Public Methods
    }
}