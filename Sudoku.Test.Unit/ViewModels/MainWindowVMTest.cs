using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Sudoku.Services;
using Sudoku.Test.Unit.TestHelper;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    //[TestClass]
    //public class MainWindowVMTest
    //{
    //    private Mock<ISudokuGenerator> _sudokuGeneratorMock;

    //    private Mock<IPuzzleGenerator> _puzzleGeneratorMock;

    //    private IMainWindowVM _mainWindowVM;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        _sudokuGeneratorMock = new Mock<ISudokuGenerator>();
    //        _puzzleGeneratorMock = new Mock<IPuzzleGenerator>();
    //        _mainWindowVM = new MainWindowVM(_sudokuGeneratorMock.Object, _puzzleGeneratorMock.Object);
    //    }

    //    [TestMethod]
    //    public void ContentPropertyRaisesPropertyChanged()
    //    {
    //        _mainWindowVM.RaisesPropertyChanged(p => p.Content).When(p => p.Content = null);
    //    }
    //}
}
