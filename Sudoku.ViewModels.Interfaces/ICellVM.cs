using System;

using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels.Interfaces
{
    public interface ICellVM : IViewModelBase
    {
        #region Events

        event EventHandler<NumberChangedEventArgs> NumberChanged;

        #endregion Events

        #region Properties

        int Index
        {
            get;
        }

        bool IsSelected
        {
            get; set;
        }

        int Number
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        int GetBox();

        int GetColumn();

        int GetRow();

        #endregion Methods
    }
}