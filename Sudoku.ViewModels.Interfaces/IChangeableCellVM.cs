using System.Collections.Generic;
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

        void TogglePencilMark(int index);

        void DisablePencilMarks(IEnumerable<int> numbers);

        void EnableAllPencilMarks();
    }
}