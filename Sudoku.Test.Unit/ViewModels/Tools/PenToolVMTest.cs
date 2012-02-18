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
        public void EnteringNumberWhenNumberIsZeroSetsTheNumber()
        {
            _penToolVM.EnterNumber(1);

            Assert.AreEqual(1, _cellVMMock.Object.Number);
        }

        [TestMethod]
        public void EnteringSamNumberAgainWillSetTheNumberToZero()
        {
            _penToolVM.EnterNumber(1);
            _penToolVM.EnterNumber(1);

            Assert.AreEqual(0, _cellVMMock.Object.Number);
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