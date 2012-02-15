using System.Collections.Generic;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameBoardVM : IViewModelBase
    {
        List<ICellVM> Cells { get; }

        ICellVM SelectedCell { get; set; }
    }
}