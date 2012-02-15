using System.Collections.ObjectModel;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameVM : IViewModelBase
    {
        ICommand EnterNumberCommand { get; }

        ReadOnlyCollection<IToolVM> Tools { get; }

        IGameBoardVM GameBoard { get; }

        ISelectableToolVM SelectedTool { get; }
    }
}