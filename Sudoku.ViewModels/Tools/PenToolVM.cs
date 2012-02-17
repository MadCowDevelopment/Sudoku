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

        public override void EnterNumber(IChangeableCellVM cellVM, int number)
        {
            cellVM.Number = cellVM.Number == number ? 0 : number;
        }

        #endregion Public Methods
    }
}