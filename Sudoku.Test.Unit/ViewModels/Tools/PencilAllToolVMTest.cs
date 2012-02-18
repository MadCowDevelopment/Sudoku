using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.Test.Unit.ViewModels.Tools
{
    [TestClass]
    public class PencilAllToolVMTest
    {
        private IPencilAllToolVM _pencilAllToolVM;

        private Mock<IGameBoardVM> _gameBoardVMMock;

        [TestInitialize]
        public void Initialize()
        {
            _gameBoardVMMock = new Mock<IGameBoardVM>();

            _pencilAllToolVM = new PencilAllToolVM(_gameBoardVMMock.Object);
        }

        [TestMethod]
        public void ImageIsSetCorrectly()
        {
            Assert.AreEqual(@"..\Images\PencilAll.png", _pencilAllToolVM.Image);
        }
    }
}
