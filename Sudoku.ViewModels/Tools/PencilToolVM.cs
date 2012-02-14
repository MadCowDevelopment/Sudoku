namespace Sudoku.ViewModels.Tools
{
    public class PencilToolVM : ToggleToolVM
    {
        public PencilToolVM(GameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pencil.png";
        }

        public override void EnterNumber(CellVM cellVM, int number)
        {
            
        }
    }
}
