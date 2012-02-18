using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class PencilToolVM : SelectableToolVM, IPencilToolVM
    {
        #region Constructors

        public PencilToolVM(IGameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pencil.png";
        }

        #endregion Constructors

        #region Public Methods

        public override void EnterNumber(int number)
        {
            var cell = (IChangeableCellVM)GameBoardVM.SelectedCell;
            if (cell.Number != 0)
            {
                return;
            }

            cell.PencilMarks[number - 1] = cell.PencilMarks[number - 1] == number ? 0 : number;
        }

        #endregion Public Methods
    }
}