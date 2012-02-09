using System.Collections.ObjectModel;

namespace Sudoku.ViewModels
{
    public class ChangeableCellVM : CellVM
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
