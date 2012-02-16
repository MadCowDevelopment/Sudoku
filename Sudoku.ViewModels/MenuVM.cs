using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels
{
    [Export(typeof(IMenuVM))]
    public class MenuVM : ViewModelBase, IMenuVM
    {
        private ICommand _startGameCommand;

        public ICommand StartGameCommand
        {
            get
            {
                return _startGameCommand ?? (_startGameCommand = new RelayCommand<Difficulty>(OnStartGame));
            }
        }

        public event EventHandler<StartGameEventArgs> StartGameRequested;

        public void RaiseStartGameRequested(StartGameEventArgs e)
        {
            var handler = StartGameRequested;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnStartGame(Difficulty difficulty)
        {
            RaiseStartGameRequested(new StartGameEventArgs(difficulty));
        }
    }
}
