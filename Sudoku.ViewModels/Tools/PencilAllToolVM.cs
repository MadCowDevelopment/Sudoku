using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    [Export(typeof(IPencilAllToolVM))]
    public class PencilAllToolVM : ExecutableToolVM, IPencilAllToolVM
    {
        #region Fields

        private readonly IGameBoardVM _gameBoardVM;

        #endregion Fields

        #region Constructors

        public PencilAllToolVM(IGameBoardVM gameBoardVM)
        {
            _gameBoardVM = gameBoardVM;
            Image = @"..\Images\PencilAll.png";
        }

        #endregion Constructors

        #region Protected Methods

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void OnExecute()
        {
            foreach (var cell in _gameBoardVM.GetAllChangeableCellsThatDontHaveANumberSet())
            {
                EnableAllPencilMarks(cell);
                DisablePencilMarksDependingOnOtherNumbersInRow(cell);
                DisablePencilMarksDependingOnOtherNumbersInColumn(cell);
                DisablePencilMarksDependingOnOtherNumbersInBox(cell);
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        private static void EnableAllPencilMarks(IChangeableCellVM cell)
        {
            cell.EnableAllPencilMarks();
        }

        #endregion Private Static Methods

        #region Private Methods

        private void DisablePencilMarksDependingOnOtherNumbersInBox(IChangeableCellVM cell)
        {
            var numbersInBox = _gameBoardVM.GetNumbersInSameBox(cell.GetBoxIndex());
            cell.DisablePencilMarks(numbersInBox);
        }

        private void DisablePencilMarksDependingOnOtherNumbersInColumn(IChangeableCellVM cell)
        {
            var numbersInColumn = _gameBoardVM.GetNumbersInSameColumn(cell.GetColumnIndex());
            cell.DisablePencilMarks(numbersInColumn);
        }

        private void DisablePencilMarksDependingOnOtherNumbersInRow(IChangeableCellVM cell)
        {
            var numbersInRow = _gameBoardVM.GetNumbersInSameRow(cell.GetRowIndex());
            cell.DisablePencilMarks(numbersInRow);
        }

        #endregion Private Methods
    }
}