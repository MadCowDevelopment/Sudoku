using System;

namespace Sudoku.ViewModels.Interfaces.Tools
{
    public interface ISelectableToolVM : IToolVM
    {
        #region Events

        event EventHandler<EventArgs> IsSelected;

        #endregion Events

        #region Properties

        bool IsChecked
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        void EnterNumber(ICellVM cellVM, int number);

        #endregion Methods
    }
}