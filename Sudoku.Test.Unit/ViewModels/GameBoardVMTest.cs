using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameBoardVMTest
    {
        #region Fields

        private Mock<ICellVM> _cellMock;
        private List<ICellVM> _cells;
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
            _cells.Add(_cellMock.Object);

            _gameBoardVM = new GameBoardVM(_cells);
        }

        [TestMethod]
        public void SelectedCellRaisesPropertyChanged()
        {
            _gameBoardVM.RaisesPropertyChanged(p => p.SelectedCell).When(p => p.SelectedCell = _cellMock.Object);
        }

        #endregion Public Methods
    }
}