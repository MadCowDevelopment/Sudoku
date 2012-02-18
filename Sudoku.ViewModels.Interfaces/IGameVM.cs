using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameVM : IViewModelBase
    {
        #region Events

        event EventHandler<EventArgs> GameCompleted;

        #endregion Events

        #region Properties

        ICommand EnterNumberCommand
        {
            get;
        }

        IGameBoardVM GameBoard
        {
            get;
        }

        ISelectableToolVM SelectedTool
        {
            get;
        }

        ReadOnlyCollection<IToolVM> Tools
        {
            get;
        }

        #endregion Properties
    }
}