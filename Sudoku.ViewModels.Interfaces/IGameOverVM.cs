using System;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.Test.Unit.ViewModels
{
    public interface IGameOverVM : IViewModelBase
    {
        #region Events

        event EventHandler<EventArgs> MenuRequested;

        #endregion Events

        #region Properties

        ICommand ReturnToMenuCommand
        {
            get;
        }

        #endregion Properties
    }
}