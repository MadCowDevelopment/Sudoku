using System;
using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    [Export(typeof(IFixedCellVM))]
    public class FixedCellVM : CellVM, IFixedCellVM
    {
        #region Constructors

        public FixedCellVM(int actualValue)
            : base(actualValue)
        {
            if (actualValue < 1 || actualValue > 9)
            {
                throw new ArgumentException("The actual value must be between 1 and 9");
            }
        }

        #endregion Constructors
    }
}