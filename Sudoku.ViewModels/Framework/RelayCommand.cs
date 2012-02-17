using System;
using System.Windows.Input;

namespace Sudoku.ViewModels.Framework
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
            : this(commandAction, null)
        {
        }

        public RelayCommand(Action<T> commandAction, Func<T, bool> canExecuteFunc)
        {
            if (commandAction == null)
            {
                throw new ArgumentNullException();
            }

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

            var type = typeof(T);
            if (parameter.GetType() == type)
            {
                return (T)parameter;
            }

            if (type.IsEnum)
            {
                return (T)Enum.Parse(type, parameter.ToString(), true);
            }

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
            if (commandAction == null)
            {
                throw new ArgumentNullException();
            }
        }

        public RelayCommand(Action commandAction, Func<bool> canExecuteFunc)
            : base(o => commandAction(), o => canExecuteFunc())
        {
            if (commandAction == null)
            {
                throw new ArgumentNullException();
            }
        }

        #endregion Constructors
    }
}