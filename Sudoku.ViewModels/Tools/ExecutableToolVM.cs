using System.Windows.Input;

using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public abstract class ExecutableToolVM : ToolVM, IExecutableToolVM
    {
        #region Fields

        private ICommand _executeCommand;

        #endregion Fields

        #region Public Properties

        public ICommand ExecuteCommand
        {
            get
            {
                return _executeCommand ?? (_executeCommand = new RelayCommand(OnExecute, CanExecute));
            }
        }

        #endregion Public Properties

        #region Protected Methods

        protected abstract bool CanExecute();

        protected abstract void OnExecute();

        #endregion Protected Methods
    }
}