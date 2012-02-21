using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Sudoku.Models;

// At the moment the puzzle generator creates not only unique solutions.
// The following algorithm could solve this problem.
//
//http://stackoverflow.com/questions/6924216/how-to-generate-sudoku-boards-with-unique-solutions
//Here is the way my own SuDoKu program does it:
//
// 1) start with a complete, valid board (filled with 81 numbers)
// 2) make a list of all 81 cell positions and shuffle it randomly
// 3) As long as the list is not empty, take the next position from the list and remove the number from the related cell
// 4) test uniqueness using a fast solver (with backtracking if needed). 
//    My solver could count all solutions, but it stops when it found more than 1 solution.
// 5) If the current board has just one solution, goto step 3) and repeat.
// 6) If the current board has more than one solution, undo the last removal (step 3), 
//    and continue step 3 with the next position from the list
// 7) stop when you have tested all 81 positions.
//    This gives you not only unique boards, but boards where you cannot remove any more numbers without destroying 
//    the uniqueness of the solution.

// Link to a probably fast solver: http://www.byteauthor.com/2010/08/sudoku-solver-update/

namespace Sudoku.Services
{
    [Export(typeof(IPuzzleGenerator))]
    public class PuzzleGenerator : IPuzzleGenerator
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Methods

        public void GeneratePuzzle(GameBoard gameBoard, Difficulty difficulty)
        {
            int numberOfSolutions;
            List<int> indices;
            do
            {
                indices = GetIndicesToRemoveDependingOnDifficulty(difficulty);

                var fields = new int[81];
                for (var i = 0; i < 81; i++)
                {
                    if (indices.Contains(i))
                    {
                        fields[i] = 0;
                    }
                    else
                    {
                        fields[i] = gameBoard.Fields[i];
                    }
                }

                numberOfSolutions = SolvePuzzle(new GameBoard(fields));
            } 
            while (numberOfSolutions != 1);

            foreach (var index in indices)
            {
                gameBoard.Fields[index] = 0;
            }
        }

        private int SolvePuzzle(GameBoard gameBoard)
        {
            var numbers = Enumerable.Range(1, 9).ToList();

            var solutions = 0;
            for (var i = 0; i < 81; i++)
            {
                if (gameBoard.Fields[i] != 0)
                {
                    continue;
                }

                foreach (var number in numbers)
                {
                    gameBoard.Fields[i] = number;
                    var result = SolvePuzzleRec(gameBoard);
                    if (result)
                    {
                        solutions++;
                        if (solutions > 1)
                        {
                            return solutions;
                        }
                    }
                }
            }

            return solutions;
        }

        public bool SolvePuzzleRec(GameBoard gameBoard)
        {
            var numbers = Enumerable.Range(1, 9).ToList();

            for (var i = 0; i < 81; i++)
            {
                if (gameBoard.Fields[i] != 0)
                {
                    continue;
                }

                foreach (var number in numbers)
                {
                    gameBoard.Fields[i] = number;

                    if (!gameBoard.IsValid())
                    {
                        continue;
                    }

                    if (gameBoard.IsCompleted())
                    {
                        return true;
                    }

                    var result = SolvePuzzleRec(gameBoard);
                    if (result)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private List<int> GetIndicesToRemoveDependingOnDifficulty(Difficulty difficulty)
        {
            var numbers = Enumerable.Range(0, 81).OrderBy(p => _random.Next(0, 81)).ToList();

            switch (difficulty)
            {
                case Difficulty.VeryEasy:
                    numbers = numbers.Take(3).ToList();
                    break;
                case Difficulty.Easy:
                    numbers = numbers.Take(40).ToList();
                    break;
                case Difficulty.Medium:
                    numbers = numbers.Take(30).ToList();
                    break;
                case Difficulty.Hard:
                    numbers = numbers.Take(26).ToList();
                    break;
                case Difficulty.Extreme:
                    numbers = numbers.Take(17).ToList();
                    break;
            }

            return numbers;
        }

        #endregion Public Methods
    }
}