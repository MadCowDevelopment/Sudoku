using System;
using System.ComponentModel.Composition;
using System.Linq;

using Sudoku.Models;

namespace Sudoku.Services
{
    [Export(typeof(IPuzzleGenerator))]
    public class PuzzleGenerator : IPuzzleGenerator
    {
        #region Fields

        private Random _random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Methods

        public void GeneratePuzzle(GameBoard gameBoard, Difficulty difficulty)
        {
            var numbers = Enumerable.Range(0, 81).OrderBy(p => _random.Next(0, 81)).ToList();

            switch (difficulty)
            {
                case Difficulty.VeryEasy:
                    numbers = numbers.Take(70).ToList();
                    break;
                case Difficulty.Easy:
                    numbers = numbers.Take(60).ToList();
                    break;
                case Difficulty.Medium:
                    numbers = numbers.Take(40).ToList();
                    break;
                case Difficulty.Hard:
                    numbers = numbers.Take(25).ToList();
                    break;
                case Difficulty.Extreme:
                    numbers = numbers.Take(17).ToList();
                    break;
            }

            for (int i = 0; i < 81; i++)
            {
                if (!numbers.Contains(i))
                {
                    gameBoard.Fields[i] = 0;
                }
            }
        }

        #endregion Public Methods
    }
}