using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class FixedCellVMTest
    {
        #region Public Methods

        [TestMethod]
        public void ConstructorArgumentNineIsOk()
        {
            CreateFixedCellVM(9);
        }

        [TestMethod]
        public void ConstructorArgumentOneIsOk()
        {
            CreateFixedCellVM(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorArgumentTenThrowsException()
        {
            CreateFixedCellVM(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorArgumentZeroThrowsException()
        {
            CreateFixedCellVM(0);
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateFixedCellVM(int number)
        {
            new FixedCellVM(0, number);
        }

        #endregion Private Methods
    }
}