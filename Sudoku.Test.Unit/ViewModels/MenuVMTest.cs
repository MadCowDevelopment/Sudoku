using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Models;
using Sudoku.ViewModels;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class MenuVMTest
    {
        private IMenuVM _menuVM;

        [TestInitialize]
        public void Initialize()
        {
            _menuVM = new MenuVM();
        }

        [TestMethod]
        public void ExecutingCommandToStartEasyGameRaisesStartGameEvent()
        {
            AssertGameStartIsRequestedWith(Difficulty.Easy);
        }

        [TestMethod]
        public void ExecutingCommandToStartMediumGameRaisesStartGameEvent()
        {
            AssertGameStartIsRequestedWith(Difficulty.Medium);
        }

        [TestMethod]
        public void ExecutingCommandToStartHardGameRaisesStartGameEvent()
        {
            AssertGameStartIsRequestedWith(Difficulty.Hard);
        }

        private void AssertGameStartIsRequestedWith(Difficulty difficulty)
        {
            StartGameEventArgs eventArgs = null;
            bool eventWasRaised = false;
            _menuVM.StartGameRequested += (sender, args) =>
                {
                    eventArgs = args;
                    eventWasRaised = true;
                };

            _menuVM.StartGameCommand.Execute(difficulty);

            Assert.IsTrue(eventWasRaised);
            Assert.AreEqual(difficulty, eventArgs.Difficulty);
        }
    }
}
