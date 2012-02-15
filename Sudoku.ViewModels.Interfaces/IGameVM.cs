using System.Collections.ObjectModel;
using System.Windows.Input;

using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameVM : IViewModelBase
    {
        ICommand EnterNumberCommand { get; }

        ObservableCollection<IToolVM> Tools { get; }

        IGameBoardVM GameBoard { get; }
    }
}