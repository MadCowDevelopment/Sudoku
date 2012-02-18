using System.Collections.ObjectModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PencilToolVMTest
    {
        #region Fields

        private Mock<IChangeableCellVM> _cellVMMock;
        private IPencilToolVM _pencilToolVM;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void EnteringNumberWhenNumberIsZeroSetsTheNumber()
        {
            _pencilToolVM.EnterNumber(_cellVMMock.Object, 1);

            Assert.AreEqual(1, _cellVMMock.Object.PencilMarks[0]);
        }

        [TestMethod]
        public void EnteringSamNumberAgainWillSetTheNumberToZero()
        {
            _pencilToolVM.EnterNumber(_cellVMMock.Object, 1);
            _pencilToolVM.EnterNumber(_cellVMMock.Object, 1);

            Assert.AreEqual(0, _cellVMMock.Object.PencilMarks[0]);
        }

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\Pencil.png", _pencilToolVM.Image);
        }

        [TestInitialize]
        public void Initialize()
        {
            _pencilToolVM = new PencilToolVM(null);
            _cellVMMock = new Mock<IChangeableCellVM>();
            _cellVMMock.Setup(p => p.PencilMarks).Returns(new ObservableCollection<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        #endregion Public Methods
    }
}