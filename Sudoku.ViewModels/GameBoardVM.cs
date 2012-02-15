using System.Collections.Generic;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class GameBoardVM : ViewModelBase, IGameBoardVM
    {
        public GameBoardVM(IEnumerable<ICellVM> cells)
        {
            Cells = new List<ICellVM>(cells);
        }

        public List<ICellVM> Cells { get; private set; }

        private ICellVM _selectedCell;

        public ICellVM SelectedCell
        {
            get
            {
                return _selectedCell;
            }

            set
            {
                _selectedCell = value;
                RaisePropertyChanged("SelectedCell");
            }
        }
    }
}
