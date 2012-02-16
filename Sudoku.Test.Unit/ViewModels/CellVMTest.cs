﻿using System;

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
        public void IsSelectedPropertyRaisesPropertyChanged()
        {
            _cellVM.RaisesPropertyChanged(p => p.IsSelected).When(p => p.IsSelected = true);
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