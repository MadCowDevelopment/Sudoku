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
                    Cells.Add(new ChangeableCellVM());
                }
            }
        }

        public List<CellVM> Cells { get; private set; }
    
    }
}
