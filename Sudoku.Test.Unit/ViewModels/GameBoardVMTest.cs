using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Models;
using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameBoardVMTest
    {
        #region Fields

        private List<ICellVM> _cells;

        private Mock<IGameBoard> _gameBoard;

        private IGameBoardVM _gameBoardVM;

        private Mock<IChangeableCellVM> _changeableCellMock1;

        private Mock<IChangeableCellVM> _changeableCellMock2;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void AListOfChangeableCellsThatDontHaveANumberSetCanBeRetrieved()
        {
            var cells = _gameBoardVM.GetAllChangeableCellsThatDontHaveANumberSet().ToList();

            Assert.AreEqual(2, cells.Count);
            Assert.IsTrue(cells.Contains(_changeableCellMock1.Object));
            Assert.IsTrue(cells.Contains(_changeableCellMock2.Object));
        }

        [TestMethod]
        public void CellCanBeSet()
        {
            _gameBoardVM.SelectedCell = _changeableCellMock1.Object;

            Assert.AreEqual(_changeableCellMock1.Object, _gameBoardVM.SelectedCell);
        }

        [TestMethod]
        public void ConstructorInitializesCellsCollection()
        {
            Assert.AreEqual(_changeableCellMock1.Object, _gameBoardVM.Cells[0]);
            Assert.AreEqual(_changeableCellMock2.Object, _gameBoardVM.Cells[1]);
        }

        [TestMethod]
        public void GetNumbersInSameBoxShouldReturnTheSameAsGameBoard()
        {
            var fields = new int[81];
            _gameBoard.Setup(p => p.GetBox(0)).Returns(fields);

            var numbers = _gameBoardVM.GetNumbersInSameBox(0);

            Assert.AreEqual(fields, numbers);
        }

        [TestMethod]
        public void GetNumbersInSameColumnShouldReturnTheSameAsGameBoard()
        {
            var fields = new int[81];
            _gameBoard.Setup(p => p.GetColumn(0)).Returns(fields);

            var numbers = _gameBoardVM.GetNumbersInSameColumn(0);

            Assert.AreEqual(fields, numbers);
        }

        [TestMethod]
        public void GetNumbersInSameRowShouldReturnTheSameAsGameBoard()
        {
            var fields = new int[81];
            _gameBoard.Setup(p => p.GetRow(0)).Returns(fields);

            var numbers = _gameBoardVM.GetNumbersInSameRow(0);

            Assert.AreEqual(fields, numbers);
        }

        [TestInitialize]
        public void Initialize()
        {
            _gameBoard = new Mock<IGameBoard>();

            _cells = new List<ICellVM>();
            _changeableCellMock1 = new Mock<IChangeableCellVM>();
            _changeableCellMock1.Setup(p => p.Index).Returns(0);
            _changeableCellMock1.Setup(p => p.GetRowIndex()).Returns(0);
            _changeableCellMock1.Setup(p => p.GetColumnIndex()).Returns(0);
            _changeableCellMock1.Setup(p => p.GetBoxIndex()).Returns(0);
            _changeableCellMock1.Setup(p => p.PencilMarks).Returns(new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            _changeableCellMock2 = new Mock<IChangeableCellVM>();
            _changeableCellMock2.Setup(p => p.Index).Returns(1);
            _changeableCellMock2.Setup(p => p.GetColumnIndex()).Returns(1);
            _changeableCellMock2.Setup(p => p.GetBoxIndex()).Returns(0);
            _changeableCellMock2.Setup(p => p.PencilMarks).Returns(new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            _cells.Add(_changeableCellMock1.Object);
            _cells.Add(_changeableCellMock2.Object);

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
            _gameBoardVM.RaisesPropertyChanged(p => p.SelectedCell).When(p => p.SelectedCell = _changeableCellMock1.Object);
        }

        [TestMethod]
        public void WhenACellChangesTheNumberShouldBeUpdatedInTheGameBoard()
        {
            _gameBoard.Setup(p => p.Fields).Returns(new int[81]);

            _changeableCellMock1.Raise(p => p.NumberChanged += null, new NumberChangedEventArgs(1));

            Assert.AreEqual(1, _gameBoard.Object.Fields[0]);
        }

        [TestMethod]
        public void DisablingPencilMarksDisablesAllPencilMarksInARow()
        {
            _gameBoardVM.DisablePencilMarksForNumberInRow(1, 0);

            Assert.AreEqual(0, _changeableCellMock1.Object.PencilMarks[0]);
            Assert.AreEqual(0, _changeableCellMock2.Object.PencilMarks[0]);
        }

        [TestMethod]
        public void DisablingPencilMarksDisablesAllPencilMarksInAColumn()
        {
            _gameBoardVM.DisablePencilMarksForNumberInColumn(1, 0);

            Assert.AreEqual(0, _changeableCellMock1.Object.PencilMarks[0]);
            Assert.AreEqual(1, _changeableCellMock2.Object.PencilMarks[0]);
        }

        [TestMethod]
        public void DisablingPencilMarksDisablesAllPencilMarksInABox()
        {
            _gameBoardVM.DisablePencilMarksForNumberInBox(1, 0);

            Assert.AreEqual(0, _changeableCellMock1.Object.PencilMarks[0]);
            Assert.AreEqual(0, _changeableCellMock2.Object.PencilMarks[0]);
        }

        #endregion Public Methods
    }
}