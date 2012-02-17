using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.Services;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IGameBoardVMFactory))]
    public class GameBoardVMFactory : IGameBoardVMFactory
    {
        #region Fields

        private readonly IPuzzleGenerator _puzzleGenerator;
        private readonly ISudokuGenerator _sudokuGenerator;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public GameBoardVMFactory(ISudokuGenerator sudokuGenerator, IPuzzleGenerator puzzleGenerator)
        {
            _sudokuGenerator = sudokuGenerator;
            _puzzleGenerator = puzzleGenerator;
        }

        #endregion Constructors

        #region Public Methods

        public IGameBoardVM CreateInstance(Difficulty difficulty)
        {
            var gameBoard = _sudokuGenerator.GeneratePuzzle();
            _puzzleGenerator.GeneratePuzzle(gameBoard, difficulty);

            var cells = new List<ICellVM>();

            foreach (var value in gameBoard.Fields)
            {
                if (value != 0)
                {
                    cells.Add(new FixedCellVM(value));
                }
                else
                {
                    cells.Add(new ChangeableCellVM());
                }
            }

            var gameBoardVM = new GameBoardVM(cells);
            return gameBoardVM;
        }

        #endregion Public Methods
    }
}