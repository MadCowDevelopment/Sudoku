using System.Collections.Generic;

using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IGameBoardVM : IViewModelBase
    {
        #region Properties

        List<ICellVM> Cells
        {
            get;
        }

        bool IsCompleted
        {
            get;
        }

        ICellVM SelectedCell
        {
            get; set;
        }

        IGameBoard GameBoard { get; }

        #endregion Properties
    }
}