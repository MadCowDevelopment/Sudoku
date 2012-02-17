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

        public override void EnterNumber(IChangeableCellVM cellVM, int number)
        {
            cellVM.PencilMarks[number - 1] = cellVM.PencilMarks[number - 1] == number ? 0 : number;
        }

        #endregion Public Methods
    }
}