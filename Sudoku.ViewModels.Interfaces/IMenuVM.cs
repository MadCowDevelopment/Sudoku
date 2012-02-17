using System;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IMenuVM : IViewModelBase
    {
        #region Events

        event EventHandler<StartGameEventArgs> StartGameRequested;

        #endregion Events

        #region Properties

        ICommand StartGameCommand
        {
            get;
        }

        #endregion Properties
    }
}