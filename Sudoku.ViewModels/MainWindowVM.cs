using Sudoku.Models;
using Sudoku.Services;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public class MainWindowVM : ViewModelBase, IMainWindowVM
    {
        private readonly ISudokuGenerator _sudokuGenerator;

        private readonly IPuzzleGenerator _puzzleGenerator;

        private IViewModelBase _content;

        public MainWindowVM(ISudokuGenerator sudokuGenerator, IPuzzleGenerator puzzleGenerator)
        {
            _sudokuGenerator = sudokuGenerator;
            _puzzleGenerator = puzzleGenerator;

            var gameBoard = sudokuGenerator.GeneratePuzzle();
            puzzleGenerator.GeneratePuzzle(gameBoard, Difficulty.Easy);

            Content = new GameVM(new GameBoardVM(gameBoard));
        }

        public IViewModelBase Content
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