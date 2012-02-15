using System.Collections.ObjectModel;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IChangeableCellVM : ICellVM
    {
        ObservableCollection<int> PencilMarks { get; }
    }
}