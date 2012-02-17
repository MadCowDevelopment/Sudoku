using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.ViewModels.Framework;

namespace Sudoku.Test.Unit.ViewModels.Framework
{
    [TestClass]
    public class GenericRelayCommandTest
    {
        private RelayCommand<int> _intRelayCommand;

        private RelayCommand<DummyEnum> _enumRelayCommand; 

        private int _intArgument;

        private DummyEnum _enumArgument;

        private bool _canExecute;

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenericCommandActionIsNotAllowedToBeNullForOverloadedConstructor()
        {
            _intRelayCommand = new RelayCommand<int>(null, CanExecuteFunction);
        }

        [TestMethod]
        public void CorrectArgumentIsSent()
        {
            _intRelayCommand = new RelayCommand<int>(ExecuteFunction, CanExecuteFunction);

            _intRelayCommand.Execute(1);

            Assert.AreEqual(1, _intArgument);
        }

        [TestMethod]
        public void CorrectStringCanBeParsedToEnumType()
        {
            _enumRelayCommand = new RelayCommand<DummyEnum>(ExecuteFunction, CanExecuteFunction);

            _enumRelayCommand.Execute("AnotherValue");

            Assert.AreEqual(DummyEnum.AnotherValue, _enumArgument);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectStringThrowsException()
        {
            _enumRelayCommand = new RelayCommand<DummyEnum>(ExecuteFunction, CanExecuteFunction);

            _enumRelayCommand.Execute("InvalidValue");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongTypeThrowsException()
        {
            _intRelayCommand = new RelayCommand<int>(ExecuteFunction, CanExecuteFunction);

            _intRelayCommand.Execute(0.0);
        }

        private void ExecuteFunction(int i)
        {
            _intArgument = i;
        }

        private void ExecuteFunction(DummyEnum argument)
        {
            _enumArgument = argument;
        }
        
        private bool CanExecuteFunction(int argument)
        {
            return _canExecute;
        }

        private bool CanExecuteFunction(DummyEnum argument)
        {
            return _canExecute;
        }

        private enum DummyEnum
        {
            OneValue,
            AnotherValue
        }
    }
}
