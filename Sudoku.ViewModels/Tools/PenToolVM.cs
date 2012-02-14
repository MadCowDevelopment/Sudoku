namespace Sudoku.ViewModels.Tools
{
    public class PenToolVM : ToggleToolVM
    {
        public PenToolVM(GameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pen.png";
        }

        public override void EnterNumber(CellVM cellVM, int number)
        {
            cellVM.Number = cellVM.Number == number ? 0 : number;
        }
    }
}
