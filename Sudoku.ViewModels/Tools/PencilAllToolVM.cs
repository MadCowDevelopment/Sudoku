using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

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
            foreach (var cell in _gameBoardVM.Cells.OfType<IChangeableCellVM>().Where(p=>p.Number == 0))
            {
                EnableAllPencilMarks(cell);
                DisablePencilMarksDependingOnOtherNumbersInRow(cell);
                DisablePencilMarksDependingOnOtherNumbersInColumn(cell);
                DisablePencilMarksDependingOnOtherNumbersInBox(cell);
            }
        }

        private void DisablePencilMarksDependingOnOtherNumbersInBox(IChangeableCellVM cell)
        {
            var numbersInBox = _gameBoardVM.GameBoard.GetBox(cell.GetBox());
            DisablePencilMarksDependingOnOtherNumbers(cell, numbersInBox);
        }

        private void DisablePencilMarksDependingOnOtherNumbers(IChangeableCellVM cell, IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number != 0)
                {
                    cell.PencilMarks[number - 1] = 0;
                }
            }
        }

        private void DisablePencilMarksDependingOnOtherNumbersInColumn(IChangeableCellVM cell)
        {
            var numbersInColumn = _gameBoardVM.GameBoard.GetColumn(cell.GetColumn());
            DisablePencilMarksDependingOnOtherNumbers(cell, numbersInColumn);
        }

        private void DisablePencilMarksDependingOnOtherNumbersInRow(IChangeableCellVM cell)
        {
            var numbersInRow = _gameBoardVM.GameBoard.GetRow(cell.GetRow());
            DisablePencilMarksDependingOnOtherNumbers(cell, numbersInRow);
        }

        private static void EnableAllPencilMarks(IChangeableCellVM cell)
        {
            for (int i = 0; i < 9; i++)
            {
                cell.PencilMarks[i] = i + 1;
            }
        }
    }
}
