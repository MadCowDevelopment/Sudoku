using Sudoku.Models;
using Sudoku.Services;

namespace Sudoku.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly ISudokuGenerator _sudokuGenerator;

        private readonly IPuzzleGenerator _puzzleGenerator;

        private ViewModelBase _content;

        public MainWindowVM(ISudokuGenerator sudokuGenerator, IPuzzleGenerator puzzleGenerator)
        {
            _sudokuGenerator = sudokuGenerator;
            _puzzleGenerator = puzzleGenerator;

            var gameBoard = sudokuGenerator.GeneratePuzzle();
            puzzleGenerator.GeneratePuzzle(gameBoard, Difficulty.Easy);

            Content = new GameVM(new GameBoardVM(gameBoard));
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