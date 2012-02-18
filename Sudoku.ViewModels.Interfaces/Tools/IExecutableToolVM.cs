using System.Windows.Input;

namespace Sudoku.ViewModels.Interfaces.Tools
{
    public interface IExecutableToolVM : IToolVM
    {
        ICommand ExecuteCommand { get; }
    }
}
