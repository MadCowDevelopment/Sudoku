using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class FixedCellVMTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorArgumentZeroThrowsException()
        {
            CreateFixedCellVM(0);
        }

        [TestMethod]
        public void ConstructorArgumentOneIsOk()
        {
            CreateFixedCellVM(1);
        }

        [TestMethod]
        public void ConstructorArgumentNineIsOk()
        {
            CreateFixedCellVM(9);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorArgumentTenThrowsException()
        {
            CreateFixedCellVM(10);
        }

        private void CreateFixedCellVM(int number)
        {
            new FixedCellVM(number);
        }
    }
}
