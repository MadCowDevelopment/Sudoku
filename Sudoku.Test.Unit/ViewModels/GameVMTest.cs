using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameVMTest
    {
        #region Fields

        private Mock<IGameBoardVM> _gameBoardVMMock;
        private IGameVM _gameVM;
        private Mock<ISelectableToolVM> _selectableToolMock;
        private List<IToolVM> _tools;

        #endregion Fields

        #region Public Methods

        [TestCleanup]
        public void Cleanup()
        {
            _tools = null;
            _selectableToolMock = null;
            _gameBoardVMMock = null;
            _gameVM = null;
        }

        [TestMethod]
        public void EnterNumberCommandCallsEnterNumberOnTheSelectedToolWithTheCurrentlySelectedCell()
        {
            var selectedCell = new Mock<IChangeableCellVM>();
            _selectableToolMock.Raise(p => p.IsSelected += null, new EventArgs());
            _gameBoardVMMock.Setup(p => p.SelectedCell).Returns(selectedCell.Object);

            _gameVM.EnterNumberCommand.Execute("1");

            _selectableToolMock.Verify(
                p => p.EnterNumber(It.Is<IChangeableCellVM>(x => x == selectedCell.Object), It.Is<int>(x => x == 1)));
        }

        [TestMethod]
        public void EnterNumberCommandWithInvalidArgumentDoesNothing()
        {
            var selectedCell = new Mock<IChangeableCellVM>();
            _selectableToolMock.Raise(p => p.IsSelected += null, new EventArgs());
            _gameBoardVMMock.Setup(p => p.SelectedCell).Returns(selectedCell.Object);

            _gameVM.EnterNumberCommand.Execute("XXX");

            _selectableToolMock.Verify(
                p => p.EnterNumber(It.IsAny<IChangeableCellVM>(), It.IsAny<int>()), Times.Never());
        }

        [TestMethod]
        public void EnterNumberCommandWithNullArgumentDoesNothing()
        {
            _gameVM.EnterNumberCommand.Execute(null);

            _selectableToolMock.Verify(
                p => p.EnterNumber(It.IsAny<IChangeableCellVM>(), It.IsAny<int>()), Times.Never());
        }

        [TestMethod]
        public void EnterNumberCommandWithoutSelectedCellDoesNothing()
        {
            _selectableToolMock.Raise(p => p.IsSelected += null, new EventArgs());

            _gameVM.EnterNumberCommand.Execute("1");

            _selectableToolMock.Verify(
                p => p.EnterNumber(It.IsAny<IChangeableCellVM>(), It.IsAny<int>()), Times.Never());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnterNumberCommandWithoutSelectedToolDoesNothing()
        {
            _gameVM.EnterNumberCommand.Execute(0);
        }

        [TestInitialize]
        public void Initialize()
        {
            _tools = new List<IToolVM>();
            _selectableToolMock = new Mock<ISelectableToolVM>();
            _tools.Add(_selectableToolMock.Object);
            _gameBoardVMMock = new Mock<IGameBoardVM>();

            _gameVM = new GameVM(_gameBoardVMMock.Object, _tools);
        }

        [TestMethod]
        public void IsSelectedEventHandlerSetsTheSelectedTool()
        {
            _selectableToolMock.Raise(p => p.IsSelected += null, new EventArgs());

            Assert.AreEqual(_selectableToolMock.Object, _gameVM.SelectedTool);
        }

        #endregion Public Methods
    }
}