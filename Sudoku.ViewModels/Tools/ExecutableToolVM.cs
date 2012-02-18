using System.Windows.Input;

using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public abstract class ExecutableToolVM : ToolVM, IExecutableToolVM
    {
        private ICommand _executeCommand;

        public ICommand ExecuteCommand
        {
            get
            {
                return _executeCommand ?? (_executeCommand = new RelayCommand(OnExecute, CanExecute));
            }
        }

        protected abstract void OnExecute();

        protected abstract bool CanExecute();
    }
}
