using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class CellVMTest
    {
        private TestCellVM _cellVM;

        [TestInitialize]
        public void Initialize()
        {
            _cellVM = new TestCellVM(0);
        }

        [TestMethod]
        public void NumberPropertyRaisesPropertyChanged()
        {
            _cellVM.RaisesPropertyChanged(p => p.Number).When(p => p.Number = 0);
        }

        [TestMethod]
        public void IsSelectedPropertyRaisesPropertyChanged()
        {
            _cellVM.RaisesPropertyChanged(p => p.IsSelected).When(p => p.IsSelected = true);
        }

        private class TestCellVM : CellVM
        {
            public TestCellVM(int actualValue)
                : base(actualValue)
            {
            }
        }
    }
}
