using System.Collections.ObjectModel;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class ChangeableCellVM : CellVM, IChangeableCellVM
    {
        public ChangeableCellVM() : base(0)
        {
            PencilMarks = new ObservableCollection<int>();
            for (int i = 0; i < 9; i++)
            {
                PencilMarks.Add(i + 1);
            }
        }

        public ObservableCollection<int> PencilMarks { get; private set; }
    }
}
