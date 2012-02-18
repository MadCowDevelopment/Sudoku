using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels.Framework;

namespace Sudoku.Test.Unit.ViewModels.Framework
{
    [TestClass]
    public class RelayCommandTest
    {
        #region Fields

        private bool _actionHasBeenCalled;
        private bool _canExecute;
        private RelayCommand _relayCommand;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        public void CanExecuteIsFalseWhenPredicateReturnsFalse()
        {
            _canExecute = false;

            var actual = _relayCommand.CanExecute(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CanExecuteIsTrueWhenPredicateReturnsTrue()
        {
            _canExecute = true;

            var actual = _relayCommand.CanExecute(null);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CanExecuteIsTrueWhenThereIsNoPredicate()
        {
            _relayCommand = new RelayCommand(OnActionCalled);

            var actual = _relayCommand.CanExecute(null);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandActionIsNotAllowedToBeNull()
        {
            _relayCommand = new RelayCommand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandActionIsNotAllowedToBeNullForOverloadedConstructor()
        {
            _relayCommand = new RelayCommand(null, CanExecuteFunction);
        }

        [TestMethod]
        public void CommandIsExecuted()
        {
            _relayCommand = new RelayCommand(OnActionCalled);

            _relayCommand.Execute(null);

            Assert.AreEqual(true, _actionHasBeenCalled);
        }

        [TestMethod]
        public void ExecuteChangedEventCanBeRaised()
        {
            var eventWasRaised = false;
            _relayCommand.CanExecuteChanged += (sender, args) => { eventWasRaised = true; };

            _relayCommand.RaiseCanExecuteChanged();

            Assert.IsTrue(eventWasRaised);
        }

        [TestInitialize]
        public void Initialize()
        {
            _relayCommand = new RelayCommand(OnActionCalled, CanExecuteFunction);
            _actionHasBeenCalled = false;
        }

        #endregion Public Methods

        #region Private Methods

        private bool CanExecuteFunction()
        {
            return _canExecute;
        }

        private void OnActionCalled()
        {
            _actionHasBeenCalled = true;
        }

        #endregion Private Methods
    }
}