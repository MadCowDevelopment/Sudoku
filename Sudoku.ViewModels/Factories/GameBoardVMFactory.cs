using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.Services;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IGameBoardVMFactory))]
    public class GameBoardVMFactory : IGameBoardVMFactory
    {
        private readonly ISudokuGenerator _sudokuGenerator;

        private readonly IPuzzleGenerator _puzzleGenerator;

        [ImportingConstructor]
        public GameBoardVMFactory(ISudokuGenerator sudokuGenerator, IPuzzleGenerator puzzleGenerator)
        {
            _sudokuGenerator = sudokuGenerator;
            _puzzleGenerator = puzzleGenerator;
        }

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
    }
}