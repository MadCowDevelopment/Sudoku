using System.Collections.Generic;

namespace Sudoku.ViewModels
{
    public class GameBoardViewModel : ViewModelBase
    {
        public GameBoardViewModel()
        {
            Cells = new List<CellViewModel>();

            for (int i = 0; i < 81; i++)
            {
                Cells.Add(new CellViewModel());
            }
        }

        public List<CellViewModel> Cells { get; private set; }
    
    }
}
