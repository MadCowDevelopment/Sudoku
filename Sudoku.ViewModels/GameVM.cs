using System.Collections.ObjectModel;
using System.Windows.Input;

using Sudoku.ViewModels.Tools;

namespace Sudoku.ViewModels
{
    public class GameVM : ViewModelBase
    {
        private ToggleToolVM _selectedTool;

        public GameVM(GameBoardVM gameBoardVM)
        {
            GameBoard = gameBoardVM;

            Tools = new ObservableCollection<ToolVM>();

            var penTool = new PenToolVM(GameBoard);
            penTool.IsSelected += ToolIsSelected;

            var pencilTool = new PencilToolVM(GameBoard);
            pencilTool.IsSelected += ToolIsSelected;

            Tools.Add(penTool);
            Tools.Add(pencilTool);
        }

        private void OnNumberEntered(object obj)
        {
            if (_selectedTool == null || GameBoard.SelectedCell == null)
            {
                return;
            }

            var number = int.Parse(obj.ToString());
            _selectedTool.EnterNumber(GameBoard.SelectedCell, number);
        }

        private ICommand _enterNumberCommand;


        public ICommand EnterNumberCommand
        {
            get
            {
                return _enterNumberCommand ?? (_enterNumberCommand = new RelayCommand(OnNumberEntered));
            }
        }


        private void ToolIsSelected(object sender, System.EventArgs e)
        {
            _selectedTool = sender as ToggleToolVM;
        }

        public ObservableCollection<ToolVM> Tools { get; private set; }

        public GameBoardVM GameBoard { get; private set; }
    }
}
