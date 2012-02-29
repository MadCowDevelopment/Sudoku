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

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public GameBoardVMFactory(IPuzzleGenerator puzzleGenerator)
        {
            _puzzleGenerator = puzzleGenerator;
        }

        #endregion Constructors

        #region Public Methods

        public IGameBoardVM CreateInstance(Difficulty difficulty)
        {
            var gameBoard = _puzzleGenerator.GeneratePuzzle(difficulty);

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