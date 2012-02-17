using System;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    /// <summary>
    /// A simple relay command implementation of <c>ICommand</c>.
    /// </summary>
    /// <typeparam name="T">The type of the command parameter.</typeparam>
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Func<T, bool> _canExecuteFunc;
        private readonly Action<T> _commandAction;

        #endregion Fields

        #region Constructors

        public RelayCommand(Action<T> commandAction)
        {
            _commandAction = commandAction;
        }

        public RelayCommand(Action<T> commandAction, Func<T, bool> canExecuteFunc)
        {
            _commandAction = commandAction;
            _canExecuteFunc = canExecuteFunc;
        }

        #endregion Constructors

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion Events

        #region Public Methods

        /// <summary>
        /// Determines whether the command can be executed or not.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc == null)
            {
                return true;
            }

            var typedParameter = GetParameter(parameter);
            return _canExecuteFunc(typedParameter);
        }

        /// <summary>
        /// Executes the command with the given parameter.
        /// </summary>
        public void Execute(object parameter)
        {
            if (_commandAction == null)
            {
                return;
            }

            // we try to do some simple parsing and conversion
            var typedParameter = GetParameter(parameter);
            _commandAction(typedParameter);
        }

        /// <summary>
        /// Can be used to force a re-evaluation of the <c>CanExecute</c> method.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handlers = CanExecuteChanged;
            if (handlers != null)
            {
                handlers(this, EventArgs.Empty);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private T GetParameter(object parameter)
        {
            if (parameter == null)
            {
                return default(T);
            }

            // get the type of the parameter
            var type = typeof(T);

            // if we have identical types, simply cast the parameter
            if (parameter.GetType() == type)
            {
                return (T)parameter;
            }

            // if the type is an enum, try to parse the enum value
            if (type.IsEnum)
            {
                return (T)Enum.Parse(type, parameter.ToString(), true);
            }

            // ok, we cannot use the input parameter
            throw new ArgumentException("Input type not supported.", "parameter");
        }

        #endregion Private Methods
    }

    /// <summary>
    /// A convenient class of a relay command that takes no parameters.
    /// </summary>
    public class RelayCommand : RelayCommand<object>
    {
        #region Constructors

        public RelayCommand(Action commandAction)
            : base(o => commandAction())
        {
        }

        public RelayCommand(Action commandAction, Func<bool> canExecuteFunc)
            : base(o => commandAction(), o => canExecuteFunc())
        {
        }

        #endregion Constructors
    }
}