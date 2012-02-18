using System.Collections.Generic;

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
            var cell = GameBoardVM.SelectedCell;
            cell.Number = cell.Number == number ? 0 : number;

            var changeableCellsInSameRowAsSelectedCell = new List<IChangeableCellVM>();
        }

        #endregion Public Methods
    }
}