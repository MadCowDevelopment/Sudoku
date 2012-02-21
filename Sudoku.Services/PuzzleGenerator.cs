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
            var t = new DancingLinksEngine();
            var result = t.GenerateOne(1);

            var lines = result.StringRep.Split('\n');

            string mergedLines = string.Empty;
            foreach (var line in lines)
            {
                mergedLines += line;
            }
            for (int i = 0; i < 81; i++)
            {
                if (mergedLines[i] == '.')
                {
                    gameBoard.Fields[i] = 0;
                }
                else
                {
                    gameBoard.Fields[i] = int.Parse(mergedLines[i].ToString());
                }
            }


            //var numberOfFieldsToRemove = GetNumberOfFieldsToRemoveDependingOnDifficulty(difficulty);

            //bool isValid;
            //do
            //{
            //    var indices = Enumerable.Range(0, 81).OrderBy(p => _random.Next(0, 81)).ToList();
            //    isValid = Create(gameBoard, indices, numberOfFieldsToRemove);
            //}
            //while (!isValid);
        }

        private bool Create(GameBoard gameBoard, List<int> indices, int numberOfFieldsToRemove)
        {
            if (indices.Count <= 81 - numberOfFieldsToRemove)
            {
                return true;
            }

            do
            {
                var nextIndex = indices[0];
                
                indices.RemoveAt(0);
                var oldValue = gameBoard.Fields[nextIndex];
                gameBoard.Fields[nextIndex] = 0;

                if (SolvePuzzle(DeepCopyGameBoard(gameBoard)) == 1)
                {
                    var result = Create(gameBoard, indices, numberOfFieldsToRemove);
                    if (result)
                    {
                        return true;
                    }
                }
                else
                {
                    gameBoard.Fields[nextIndex] = oldValue;
                }
            }
            while (indices.Count > 81 - numberOfFieldsToRemove);

            return false;
        }

        private GameBoard DeepCopyGameBoard(GameBoard gameBoard)
        {
            var fields = new int[81];
            for (int i = 0; i < 81; i++)
            {
                fields[i] = gameBoard.Fields[i];
            }

            return new GameBoard(fields);
        }

        private int SolvePuzzle(GameBoard gameBoard)
        {
            var solutionsFound = 0;
            SolvePuzzleRec(gameBoard, ref solutionsFound);
            return solutionsFound;
        }

        public void SolvePuzzleRec(GameBoard gameBoard, ref int solutionsFound)
        {
            var numbers = Enumerable.Range(1, 9).ToList();

            var indexOfFirstEmptyField = -1;
            for (int i = 0; i < 81; i++)
            {
                if (gameBoard.Fields[i] == 0)
                {
                    indexOfFirstEmptyField = i;
                    break;
                }
            }

            if (indexOfFirstEmptyField == -1)
            {
                return;
            }

            foreach (var number in numbers)
            {
                gameBoard.Fields[indexOfFirstEmptyField] = number;

                if (!gameBoard.IsValid())
                {
                    continue;
                }

                if (gameBoard.IsCompleted())
                {
                    solutionsFound++;
                    return;
                }

                SolvePuzzleRec(gameBoard, ref solutionsFound);
                if (solutionsFound > 1)
                {
                    return;
                }
            }

            gameBoard.Fields[indexOfFirstEmptyField] = 0;

        }

        private int GetNumberOfFieldsToRemoveDependingOnDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.VeryEasy:
                    return 10;
                case Difficulty.Easy:
                    return 40;
                case Difficulty.Medium:
                    return 50;
                case Difficulty.Hard:
                    return 56;
                case Difficulty.Extreme:
                    return 63;
            }

            throw new InvalidOperationException("Unsupported difficulty.");
        }

        #endregion Public Methods
    }
}