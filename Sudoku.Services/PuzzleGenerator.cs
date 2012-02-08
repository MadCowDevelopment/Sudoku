using System;
using System.Linq;

using Sudoku.Models;

namespace Sudoku.Services
{
    public class PuzzleGenerator : IPuzzleGenerator
    {
        private Random _random = new Random((int)DateTime.Now.Ticks);

        public void GeneratePuzzle(GameBoard gameBoard, Difficulty difficulty)
        {
            var numbers = Enumerable.Range(0, 81).OrderBy(p => _random.Next(0, 81)).ToList();

            switch (difficulty)
            {
                case Difficulty.Easy:
                    numbers = numbers.Take(30).ToList();
                    break;
                case Difficulty.Medium:
                    numbers = numbers.Take(20).ToList();
                    break;
                case Difficulty.Hard:
                    numbers = numbers.Take(10).ToList();
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
    }
}