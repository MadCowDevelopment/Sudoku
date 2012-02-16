using System.Collections.Generic;

using Sudoku.Models;
using Sudoku.Services;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.ViewModels
{
    public class MainWindowVM : ViewModelBase, IMainWindowVM
    {
        #region Fields

        private readonly IPuzzleGenerator _puzzleGenerator;
        private readonly ISudokuGenerator _sudokuGenerator;

        private IViewModelBase _content;

        #endregion Fields

        #region Constructors

        public MainWindowVM(
            ISudokuGenerator sudokuGenerator, 
            IPuzzleGenerator puzzleGenerator)
        {
            _sudokuGenerator = sudokuGenerator;
            _puzzleGenerator = puzzleGenerator;

            var gameBoard = sudokuGenerator.GeneratePuzzle();
            puzzleGenerator.GeneratePuzzle(gameBoard, Difficulty.Easy);

            var cells = new List<ICellVM>();

            foreach (var value in gameBoard.Fields)
            {
                if (value != 0)
                {
                    cells.Add(new FixedCellVM(value));
                }
                else
                {
                    var cell = new ChangeableCellVM();
                    cells.Add(cell);
                }
            }

            var gameBoardVM = new GameBoardVM(cells);
            var penTool = new PenToolVM(gameBoardVM);
            var pencilTool = new PencilToolVM(gameBoardVM);
            var tools = new List<IToolVM> { penTool, pencilTool };
            Content = new GameVM(gameBoardVM, tools);
        }

        #endregion Constructors

        #region Public Properties

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

        #endregion Public Properties
    }
}