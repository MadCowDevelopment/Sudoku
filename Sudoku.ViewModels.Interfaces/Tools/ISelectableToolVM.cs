using System;

namespace Sudoku.ViewModels.Interfaces.Tools
{
    public interface ISelectableToolVM : IToolVM
    {
        bool IsChecked { get; set; }

        event EventHandler<EventArgs> IsSelected;

        void EnterNumber(ICellVM cellVM, int number);
    }
}