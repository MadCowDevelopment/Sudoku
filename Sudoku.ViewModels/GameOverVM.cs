using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

using Sudoku.Test.Unit.ViewModels;
using Sudoku.ViewModels.Framework;

namespace Sudoku.ViewModels
{
    [Export(typeof(IGameOverVM))]
    public class GameOverVM : ViewModelBase, IGameOverVM
    {
        private ICommand _returnToMenuCommand;

        public ICommand ReturnToMenuCommand
        {
            get
            {
                return _returnToMenuCommand ?? (_returnToMenuCommand = new RelayCommand(OnGoToMenu));
            }
        }

        public event EventHandler<EventArgs> MenuRequested;

        public void RaiseMenuRequested(EventArgs e)
        {
            var handler = MenuRequested;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnGoToMenu()
        {
            RaiseMenuRequested(new EventArgs());
        }
    }
}