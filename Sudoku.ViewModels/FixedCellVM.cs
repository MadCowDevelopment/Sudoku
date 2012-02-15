using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class FixedCellVM : CellVM, IFixedCellVM
    {
        public FixedCellVM(int actualValue)
            : base(actualValue)
        {
        }
    }
}
