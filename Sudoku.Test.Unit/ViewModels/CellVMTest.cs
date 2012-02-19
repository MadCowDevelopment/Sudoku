using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class CellVMTest
    {
        #region Fields

        private ICellVM _cellVM;

        #endregion Fields

        #region Public Properties

        public TestContext TestContext
        {
            get; set;
        }

        #endregion Public Properties

        #region Public Methods

        [TestMethod]
        [DeploymentItem(@"..\..\..\Sudoku.Test.Unit\TestData\CellVMTestData.xlsx")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;dbq=|DataDirectory|\\CellVMTestData.xlsx", "GetBox$",
            DataAccessMethod.Sequential)]
        public void CorrectBoxNumberCanBeRetrieved()
        {
            AssertFunctionReturnsExpectedValueForIndexInTestData(() => _cellVM.GetBoxIndex());
        }

        [TestMethod]
        [DeploymentItem(@"..\..\..\Sudoku.Test.Unit\TestData\CellVMTestData.xlsx")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;dbq=|DataDirectory|\\CellVMTestData.xlsx", "GetColumn$",
            DataAccessMethod.Sequential)]
        public void CorrectColumnNumberCanBeRetrieved()
        {
            AssertFunctionReturnsExpectedValueForIndexInTestData(() => _cellVM.GetColumnIndex());
        }

        [TestMethod]
        [DeploymentItem(@"..\..\..\Sudoku.Test.Unit\TestData\CellVMTestData.xlsx")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;dbq=|DataDirectory|\\CellVMTestData.xlsx", "GetRow$", 
            DataAccessMethod.Sequential)]
        public void CorrectRowNumberCanBeRetrieved()
        {
            AssertFunctionReturnsExpectedValueForIndexInTestData(() => _cellVM.GetRowIndex());
        }

        [TestInitialize]
        public void Initialize()
        {
            _cellVM = new TestCellVM(0, 0);
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

        [TestMethod]
        public void SettingANumberRaisesEvent()
        {
            var eventWasRaised = false;
            _cellVM.NumberChanged += (sender, args) => { eventWasRaised = true; };

            _cellVM.Number = 1;

            Assert.IsTrue(eventWasRaised);
        }

        #endregion Public Methods

        #region Private Methods

        private void AssertFunctionReturnsExpectedValueForIndexInTestData(Func<int> function)
        {
            int index = Convert.ToInt32(TestContext.DataRow["Index"]);
            int expectedRow = Convert.ToInt32(TestContext.DataRow["Expected"]);
            _cellVM = CreateCellVM(index, 0);

            var actualRow = function();

            Assert.AreEqual(expectedRow, actualRow);
        }

        private TestCellVM CreateCellVM(int index, int actualValue)
        {
            return new TestCellVM(index, actualValue);
        }

        #endregion Private Methods

        #region Nested Types

        private class TestCellVM : CellVM
        {
            #region Constructors

            public TestCellVM(int index, int actualValue)
                : base(index, actualValue)
            {
            }

            #endregion Constructors
        }

        #endregion Nested Types
    }
}