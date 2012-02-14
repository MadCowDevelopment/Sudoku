using System.Collections.Generic;

using Sudoku.Models;

namespace Sudoku.ViewModels
{
    public class GameBoardVM : ViewModelBase
    {
        public GameBoardVM(GameBoard gameBoard)
        {
            Cells = new List<CellVM>();

            foreach (var value in gameBoard.Fields)
            {
                if (value != 0)
                {
                    Cells.Add(new FixedCellVM(value));
                }
                else
                {
                    var cell = new ChangeableCellVM();
                    Cells.Add(cell);
                }
            }
        }

        public List<CellVM> Cells { get; private set; }

        private CellVM _selectedCell;

        public CellVM SelectedCell
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
