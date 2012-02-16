using System.Collections.ObjectModel;
using System.Linq;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class ChangeableCellVM : CellVM, IChangeableCellVM
    {
        #region Constructors

        public ChangeableCellVM()
            : base(0)
        {
            PencilMarks = new ObservableCollection<int>(Enumerable.Repeat(0, 9));
        }

        #endregion Constructors

        #region Public Properties

        public ObservableCollection<int> PencilMarks
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void TogglePencilMark(int index)
        {
            PencilMarks[index] = PencilMarks[index] == 0 ? index + 1 : 0;
        }

        #endregion Public Methods
    }
}