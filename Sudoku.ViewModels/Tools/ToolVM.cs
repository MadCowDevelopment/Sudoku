using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class ToolVM : ViewModelBase, IToolVM
    {
        public string Image { get; protected set; }
    }
}
