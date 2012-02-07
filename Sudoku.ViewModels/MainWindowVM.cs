using Sudoku.Services;

namespace Sudoku.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private ViewModelBase _content;

        public MainWindowVM(ISudokuGenerator sudokuGenerator)
        {
            var gameBoard = sudokuGenerator.GeneratePuzzle();
            Content = new GameBoardViewModel(gameBoard);
        }

        public ViewModelBase Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
                RaisePropertyChanged("Content");
            }
        }
    }
}