using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PencilAllToolVMTest
    {
        private IPencilAllToolVM _pencilAllToolVM;

        [TestInitialize]
        public void Initialize()
        {
            _pencilAllToolVM = new PencilAllToolVM();
        }

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\PencilAll.png", _pencilAllToolVM.Image);
        }
    }
}
