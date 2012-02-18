using System.Collections.Generic;

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

        #endregion Properties
    }
}