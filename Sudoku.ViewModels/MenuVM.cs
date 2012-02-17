using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

using Sudoku.Models;
using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels
{
    [Export(typeof(IMenuVM))]
    public class MenuVM : ViewModelBase, IMenuVM
    {
        #region Fields

        private ICommand _startGameCommand;

        #endregion Fields

        #region Events

        public event EventHandler<StartGameEventArgs> StartGameRequested;

        #endregion Events

        #region Public Properties

        public ICommand StartGameCommand
        {
            get
            {
                return _startGameCommand ?? (_startGameCommand = new RelayCommand<Difficulty>(OnStartGame));
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void RaiseStartGameRequested(StartGameEventArgs e)
        {
            var handler = StartGameRequested;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void OnStartGame(Difficulty difficulty)
        {
            RaiseStartGameRequested(new StartGameEventArgs(difficulty));
        }

        #endregion Private Methods
    }
}