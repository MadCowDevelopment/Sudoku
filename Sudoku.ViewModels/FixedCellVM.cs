using System;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class FixedCellVM : CellVM, IFixedCellVM
    {
        public FixedCellVM(int actualValue)
            : base(actualValue)
        {
            if (actualValue < 1 || actualValue > 9)
            {
                throw new ArgumentException("The actual value must be between 1 and 9");
            }
        }
    }
}
