using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Sudoku.Models;
using Sudoku.Services.DancingLinks;

namespace Sudoku.Services
{
    [Export(typeof(IPuzzleGenerator))]
    public class PuzzleGenerator : IPuzzleGenerator
    {
        #region Public Methods

        public IGameBoard GeneratePuzzle(Difficulty difficulty)
        {
            var t = new DancingLinksEngine();
            var result = t.GenerateOne(0);

            return ConvertSudokuPuzzleToGameBoard(result, difficulty);
        }

        private IGameBoard ConvertSudokuPuzzleToGameBoard(SudokuPuzzle result, Difficulty difficulty)
        {
            var lines = result.StringRep.Split('\n');

            var mergedLines = string.Empty;
            foreach (var line in lines)
            {
                mergedLines += line;
            }

            var fields = new int[81];
            for (var i = 0; i < 81; i++)
            {
                if (mergedLines[i] == '.')
                {
                    fields[i] = 0;
                }
                else
                {
                    fields[i] = int.Parse(mergedLines[i].ToString());
                }
            }

            var gameBoard = new GameBoard(fields, difficulty);
            return gameBoard;
        }

        #endregion Public Methods
    }
}