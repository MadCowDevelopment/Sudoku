using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class ChangeableCellVMTest
    {
        private ChangeableCellVM _changeableCellVM;

        [TestInitialize]
        public void Initialize()
        {
            _changeableCellVM = new ChangeableCellVM();
        }

        [TestMethod]
        public void PencilMarksAreInitializedWithNineZeros()
        {
            _changeableCellVM = new ChangeableCellVM();

            Assert.AreEqual(9, _changeableCellVM.PencilMarks.Count);
            AssertAllPencilMarksAreZero();
        }

        [TestMethod]
        public void TogglingADisabledPencilMarkEnablesIt()
        {
            for (int i = 0; i < 9; i++)
            {
                _changeableCellVM.TogglePencilMark(i);

                Assert.AreEqual(i + 1, _changeableCellVM.PencilMarks[i]);
            }
        }

        [TestMethod]
        public void TogglingAnEnabledPencilMarkDisablesIt()
        {
            for (int i = 0; i < 9; i++)
            {
                _changeableCellVM.TogglePencilMark(i);
                _changeableCellVM.TogglePencilMark(i);

                Assert.AreEqual(0, _changeableCellVM.PencilMarks[i]);
            }
        }

        private void AssertAllPencilMarksAreZero()
        {
            for (var i = 0; i < 9; i++)
            {
                Assert.AreEqual(0, _changeableCellVM.PencilMarks[i]);
            }
        }
    }
}
