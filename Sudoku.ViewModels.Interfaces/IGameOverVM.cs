using System;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    public interface IGameOverVM : IViewModelBase
    {
        ICommand ReturnToMenuCommand { get; }

        event EventHandler<EventArgs> MenuRequested;
    }
}