using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PenToolVMTest
    {
        #region Fields

        private Mock<IChangeableCellVM> _cellVMMock;
        private Mock<IGameBoardVM> _gameBoardVMMock;
        private IPenToolVM _penToolVM;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void EnteringNumberShouldDisableAllPencilMarks()
        {
            _penToolVM.EnterNumber(1);

            _cellVMMock.Verify(p => p.DisableAllPencilMarks(), Times.Once());
        }

        [TestMethod]
        public void EnteringNumberWhenNumberIsZeroSetsTheNumber()
        {
            _penToolVM.EnterNumber(1);

            Assert.AreEqual(1, _cellVMMock.Object.Number);
        }

        [TestMethod]
        public void EnteringSameNumberAgainWillSetTheNumberToZero()
        {
            _penToolVM.EnterNumber(1);
            _penToolVM.EnterNumber(1);

            Assert.AreEqual(0, _cellVMMock.Object.Number);
        }

        [TestMethod]
        public void EnteringTwoDifferentNumbersWillSetTheSecondNumber()
        {
            _penToolVM.EnterNumber(1);
            _penToolVM.EnterNumber(2);

            Assert.AreEqual(2, _cellVMMock.Object.Number);
        }

        [TestMethod]
        public void EnterinNumberShouldRemoveTheNumberFromAllPencilMarksInTheSameBox()
        {
            _penToolVM.EnterNumber(1);

            _gameBoardVMMock.Verify(p => p.DisablePencilMarksForNumberInBox(1, 0), Times.Once());
        }

        [TestMethod]
        public void EnterinNumberShouldRemoveTheNumberFromAllPencilMarksInTheSameColumn()
        {
            _penToolVM.EnterNumber(1);

            _gameBoardVMMock.Verify(p => p.DisablePencilMarksForNumberInColumn(1, 0), Times.Once());
        }

        [TestMethod]
        public void EnterinNumberShouldRemoveTheNumberFromAllPencilMarksInTheSameRow()
        {
            _penToolVM.EnterNumber(1);

            _gameBoardVMMock.Verify(p => p.DisablePencilMarksForNumberInRow(1, 0), Times.Once());
        }

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\Pen.png", _penToolVM.Image);
        }

        [TestInitialize]
        public void Initialize()
        {
            _cellVMMock = new Mock<IChangeableCellVM>();
            _cellVMMock.SetupProperty(p => p.Number);
            _cellVMMock.Setup(p => p.Index).Returns(0);
            _cellVMMock.Setup(p => p.GetRowIndex()).Returns(0);
            _cellVMMock.Setup(p => p.GetColumnIndex()).Returns(0);
            _cellVMMock.Setup(p => p.GetBoxIndex()).Returns(0);
            _gameBoardVMMock = new Mock<IGameBoardVM>();
            _gameBoardVMMock.Setup(p => p.SelectedCell).Returns(_cellVMMock.Object);

            _penToolVM = new PenToolVM(_gameBoardVMMock.Object);
        }

        [TestMethod]
        public void SelectingTheToolRaisesAnEvent()
        {
            var eventRaised = false;
            _penToolVM.IsSelected += (sender, args) =>
                {
                    eventRaised = true;
                };

            _penToolVM.IsChecked = true;

            Assert.AreEqual(true, _penToolVM.IsChecked);
            Assert.IsTrue(eventRaised);
        }

        #endregion Public Methods
    }
}