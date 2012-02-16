using System.Collections.ObjectModel;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IChangeableCellVM : ICellVM
    {
        #region Properties

        ObservableCollection<int> PencilMarks
        {
            get;
        }

        #endregion Properties
    }
}