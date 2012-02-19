using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    [Export(typeof(IPencilAllToolVM))]
    public class PencilAllToolVM : ExecutableToolVM, IPencilAllToolVM
    {
        private readonly IGameBoardVM _gameBoardVM;

        public PencilAllToolVM(IGameBoardVM gameBoardVM)
        {
            _gameBoardVM = gameBoardVM;
            Image = @"..\Images\PencilAll.png";
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void OnExecute()
        {
            foreach (var cell in _gameBoardVM.GetChangeableCellsThatDontHaveANumberSet())
            {
                EnableAllPencilMarks(cell);
                DisablePencilMarksDependingOnOtherNumbersInRow(cell);
                DisablePencilMarksDependingOnOtherNumbersInColumn(cell);
                DisablePencilMarksDependingOnOtherNumbersInBox(cell);
            }
        }

        private static void EnableAllPencilMarks(IChangeableCellVM cell)
        {
            cell.EnableAllPencilMarks();
        }

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
    }
}
