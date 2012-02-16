using System;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IMenuVM : IViewModelBase
    {
        ICommand StartGameCommand { get; }

        event EventHandler<StartGameEventArgs> StartGameRequested;
    }
}
