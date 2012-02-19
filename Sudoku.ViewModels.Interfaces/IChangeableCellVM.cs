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

        #region Methods

        void DisablePencilMarks(IEnumerable<int> numbers);

        void EnableAllPencilMarks();

        void TogglePencilMark(int index);

        #endregion Methods
    }
}