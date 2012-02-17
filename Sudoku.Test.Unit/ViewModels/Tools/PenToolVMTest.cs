using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PenToolVMTest
    {
        private IPenToolVM _penToolVM;

        private Mock<IChangeableCellVM> _cellVMMock;
        
        [TestInitialize]
        public void Initialize()
        {
            _penToolVM = new PenToolVM(null);

            _cellVMMock = new Mock<IChangeableCellVM>();
            _cellVMMock.SetupProperty(p => p.Number);
        }

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\Pen.png", _penToolVM.Image);
        }

        [TestMethod]
        public void EnteringNumberWhenNumberIsZeroSetsTheNumber()
        {
            _penToolVM.EnterNumber(_cellVMMock.Object, 1);

            Assert.AreEqual(1, _cellVMMock.Object.Number);
        }

        [TestMethod]
        public void EnteringSamNumberAgainWillSetTheNumberToZero()
        {
            _penToolVM.EnterNumber(_cellVMMock.Object, 1);
            _penToolVM.EnterNumber(_cellVMMock.Object, 1);

            Assert.AreEqual(0, _cellVMMock.Object.Number);
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
    }
}
