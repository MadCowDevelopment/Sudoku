using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class PenToolVM : SelectableToolVM, IPenToolVM
    {
        public PenToolVM(IGameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pen.png";
        }

        public override void EnterNumber(ICellVM cellVM, int number)
        {
            cellVM.Number = cellVM.Number == number ? 0 : number;
        }
    }
}
