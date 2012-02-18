using System;
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

            for (int i = 0; i < gameBoard.Fields.Length; i++)
            {
                var value = gameBoard.Fields[i];
                if (value != 0)
                {
                    cells.Add(new FixedCellVM(i, value));
                }
                else
                {
                    cells.Add(new ChangeableCellVM(i));
                }

            }

            var gameBoardVM = new GameBoardVM(gameBoard, cells);
            return gameBoardVM;
        }

        #endregion Public Methods
    }
}