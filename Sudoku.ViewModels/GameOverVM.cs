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
        #region Fields

        private ICommand _returnToMenuCommand;

        #endregion Fields

        #region Events

        public event EventHandler<EventArgs> MenuRequested;

        #endregion Events

        #region Public Properties

        public ICommand ReturnToMenuCommand
        {
            get
            {
                return _returnToMenuCommand ?? (_returnToMenuCommand = new RelayCommand(OnGoToMenu));
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void RaiseMenuRequested(EventArgs e)
        {
            var handler = MenuRequested;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void OnGoToMenu()
        {
            RaiseMenuRequested(new EventArgs());
        }

        #endregion Private Methods
    }
}