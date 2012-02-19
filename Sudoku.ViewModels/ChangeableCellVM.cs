using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    [Export(typeof(IChangeableCellVM))]
    public class ChangeableCellVM : CellVM, IChangeableCellVM
    {
        #region Constructors

        public ChangeableCellVM(int index)
            : base(index, 0)
        {
            PencilMarks = new ObservableCollection<int>(Enumerable.Repeat(0, 9));
        }

        #endregion Constructors

        #region Public Properties

        public ObservableCollection<int> PencilMarks
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void DisablePencilMarks(IEnumerable<int> numbers)
        {
            foreach (var index in numbers)
            {
                if (index != 0)
                {
                    PencilMarks[index - 1] = 0;
                }
            }
        }

        public void EnableAllPencilMarks()
        {
            for (int i = 0; i < 9; i++)
            {
                PencilMarks[i] = i + 1;
            }
        }

        public void TogglePencilMark(int index)
        {
            PencilMarks[index] = PencilMarks[index] == 0 ? index + 1 : 0;
        }

        public void DisableAllPencilMarks()
        {
            for (int i = 0; i < 9; i++)
            {
                PencilMarks[i] = 0;
            }
        }

        #endregion Public Methods
    }
}