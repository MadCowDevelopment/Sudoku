using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels;

namespace Sudoku.Test.Unit.ViewModels
{
    [TestClass]
    public class GameOverVMTest
    {
        #region Public Methods

        [TestMethod]
        public void GoingBackToMenuCommandRaisesEvent()
        {
            var gameOverVM = new GameOverVM();
            var eventWasRaised = false;
            gameOverVM.MenuRequested += (sender, args) => { eventWasRaised = true; };

            gameOverVM.ReturnToMenuCommand.Execute(null);

            Assert.IsTrue(eventWasRaised);
        }

        #endregion Public Methods
    }
}