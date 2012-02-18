using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameBoardVMTest
    {
        #region Fields

        private Mock<ICellVM> _cellMock;
        private List<ICellVM> _cells;
        private Mock<IGameBoard> _gameBoard;
        private GameBoardVM _gameBoardVM;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void CellCanBeSet()
        {
            _gameBoardVM.SelectedCell = _cellMock.Object;

            Assert.AreEqual(_cellMock.Object, _gameBoardVM.SelectedCell);
        }

        [TestMethod]
        public void ConstructorInitializesCellsCollection()
        {
            Assert.AreEqual(_cellMock.Object, _gameBoardVM.Cells[0]);
        }

        [TestInitialize]
        public void Initialize()
        {
            _cells = new List<ICellVM>();
            _cellMock = new Mock<ICellVM>();
            _gameBoard = new Mock<IGameBoard>();
            _cells.Add(_cellMock.Object);

            _gameBoardVM = new GameBoardVM(_gameBoard.Object, _cells);
        }

        [TestMethod]
        public void IsCompletedReturnsGameBoardIsCompleted()
        {
            _gameBoard.Setup(p => p.IsCompleted()).Returns(true);

            Assert.IsTrue(_gameBoardVM.IsCompleted);
        }

        [TestMethod]
        public void SelectedCellRaisesPropertyChanged()
        {
            _gameBoardVM.RaisesPropertyChanged(p => p.SelectedCell).When(p => p.SelectedCell = _cellMock.Object);
        }

        [TestMethod]
        public void WhenACellChangesTheNumberShouldBeUpdatedInTheGameBoard()
        {
            _gameBoard.Setup(p => p.Fields).Returns(new int[81]);
            _cellMock.Setup(p => p.Index).Returns(0);

            _cellMock.Raise(p => p.NumberChanged += null, new NumberChangedEventArgs(1));

            Assert.AreEqual(1, _gameBoard.Object.Fields[0]);
        }

        #endregion Public Methods
    }
}