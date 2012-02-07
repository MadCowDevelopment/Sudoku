using System.Collections.Generic;

using Sudoku.Models;

namespace Sudoku.ViewModels
{
    public class GameBoardViewModel : ViewModelBase
    {
        public GameBoardViewModel(GameBoard gameBoard)
        {
            Cells = new List<CellViewModel>();

            foreach (var value in gameBoard.Fields)
            {
                Cells.Add(new CellViewModel(value));
            }
        }

        public List<CellViewModel> Cells { get; private set; }
    
    }
}
