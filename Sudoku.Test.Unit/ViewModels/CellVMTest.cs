using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class CellVMTest
    {
        #region Fields

        private TestCellVM _cellVM;

        #endregion Fields

        #region Public Methods

        [TestInitialize]
        public void Initialize()
        {
            _cellVM = new TestCellVM(0);
        }

        [TestMethod]
        public void IsSelectedIsSetCorrectly()
        {
            _cellVM.IsSelected = true;

            Assert.AreEqual(true, _cellVM.IsSelected);
        }

        [TestMethod]
        public void IsSelectedPropertyRaisesPropertyChanged()
        {
            _cellVM.RaisesPropertyChanged(p => p.IsSelected).When(p => p.IsSelected = true);
        }

        [TestMethod]
        public void NumberIsSetCorrectly()
        {
            _cellVM.Number = 1;

            Assert.AreEqual(1, _cellVM.Number);
        }

        [TestMethod]
        public void NumberPropertyRaisesPropertyChanged()
        {
            _cellVM.RaisesPropertyChanged(p => p.Number).When(p => p.Number = 0);
        }

        #endregion Public Methods

        #region Nested Types

        private class TestCellVM : CellVM
        {
            #region Constructors

            public TestCellVM(int actualValue)
                : base(actualValue)
            {
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}