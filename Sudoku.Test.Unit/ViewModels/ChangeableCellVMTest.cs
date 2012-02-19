using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class ChangeableCellVMTest
    {
        #region Fields

        private IChangeableCellVM _changeableCellVM;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void AllPencilMarksCanBeEnabled()
        {
            _changeableCellVM.EnableAllPencilMarks();

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(i + 1, _changeableCellVM.PencilMarks[i]);
            }
        }

        [TestMethod]
        public void AllPencilMarksShouldGetDisabledWhenSuppliedAListOfIndicesFromZeroThroughEight()
        {
            _changeableCellVM.EnableAllPencilMarks();

            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _changeableCellVM.DisablePencilMarks(numbers);

            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(0, _changeableCellVM.PencilMarks[i]);
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            _changeableCellVM = new ChangeableCellVM(0);
        }

        [TestMethod]
        public void PencilMarksAreInitializedWithNineZeros()
        {
            _changeableCellVM = new ChangeableCellVM(0);

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

        #endregion Public Methods

        #region Private Methods

        private void AssertAllPencilMarksAreZero()
        {
            for (var i = 0; i < 9; i++)
            {
                Assert.AreEqual(0, _changeableCellVM.PencilMarks[i]);
            }
        }

        #endregion Private Methods
    }
}