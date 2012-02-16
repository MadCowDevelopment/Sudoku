using System.Collections.Generic;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameBoardVM : IViewModelBase
    {
        #region Properties

        List<ICellVM> Cells
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