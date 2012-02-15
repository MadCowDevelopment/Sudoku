using System.Collections.Generic;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class GameBoardVM : ViewModelBase, IGameBoardVM
    {
        public GameBoardVM(GameBoard gameBoard)
        {
            Cells = new List<ICellVM>();

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
