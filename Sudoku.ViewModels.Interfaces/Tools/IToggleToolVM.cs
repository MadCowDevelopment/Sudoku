using System;

namespace Sudoku.ViewModels.Interfaces.Tools
{
    public interface IToggleToolVM : IToolVM
    {
        bool IsChecked { get; set; }

        event EventHandler<EventArgs> IsSelected;
    }
}