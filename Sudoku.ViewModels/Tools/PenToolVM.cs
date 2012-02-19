using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class PenToolVM : SelectableToolVM, IPenToolVM
    {
        #region Constructors

        public PenToolVM(IGameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pen.png";
        }

        #endregion Constructors

        #region Public Methods

        public override void EnterNumber(int number)
        {
            var cell = (IChangeableCellVM)GameBoardVM.SelectedCell;

            if (cell.Number == 0)
            {
                cell.Number = number;

                cell.DisableAllPencilMarks();

                GameBoardVM.DisablePencilMarksForNumberInRow(number, cell.GetRowIndex());
                GameBoardVM.DisablePencilMarksForNumberInColumn(number, cell.GetColumnIndex());
                GameBoardVM.DisablePencilMarksForNumberInBox(number, cell.GetBoxIndex());
            }
            else
            {
                cell.Number = 0;
            }
        }

        #endregion Public Methods
    }
}