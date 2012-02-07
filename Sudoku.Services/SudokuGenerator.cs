using System;
using System.Collections.Generic;
using System.Linq;

using Sudoku.Models;

namespace Sudoku.Services
{
    public class SudokuGenerator : ISudokuGenerator
    {
        #region Fields

        private GameBoard _gameBoard;

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Methods

        public GameBoard GeneratePuzzle()
        {
            _gameBoard = new GameBoard();

            var allNumbers = CreateAllNumbers().OrderBy(p => _random.Next(0, 81)).ToList();

            InitFieldRec(0, allNumbers);

            return _gameBoard;
        }

        #endregion Public Methods

        #region Private Methods

        private bool ContainsNumbersOneThroughNineMoreThanOnce(List<int> numbers)
        {
            for (var i = 1; i <= 9; i++)
            {
                if (numbers.Count(p => p == i) > 1)
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<int> CreateAllNumbers()
        {
            var result = new List<int>();
            for (var i = 0; i < 9; i++)
            {
                result.AddRange(CreateNumbersOneThroughNine());
            }

            return result;
        }

        private IEnumerable<int> CreateNumbersOneThroughNine()
        {
            return Enumerable.Range(1, 9).ToList();
        }

        private bool InitFieldRec(int index, List<int> remainingNumbers)
        {
            if (index == 81)
            {
                return true;
            }

            var chosenNumbers = new List<int>();
            for (int i = 0; i < 81 - index; i++)
            {
                if (chosenNumbers.Count == 9)
                {
                    break;
                }

                var nextNumber = remainingNumbers[i];
                if (chosenNumbers.Contains(nextNumber))
                {
                    continue;
                }

                chosenNumbers.Add(nextNumber);

                _gameBoard.Fields[index] = nextNumber;

                if (IsValid())
                {
                    var passingNumbers = remainingNumbers.ToList();
                    passingNumbers.RemoveAt(i);
                    if (InitFieldRec(index + 1, passingNumbers))
                    {
                        return true;
                    }
                }
            }

            _gameBoard.Fields[index] = 0;
            return false;
        }

        private bool IsValid()
        {
            for (int i = 0; i < 9; i++)
            {
                var row = _gameBoard.GetRow(i).ToList();
                if (ContainsNumbersOneThroughNineMoreThanOnce(row))
                {
                    return false;
                }

                var column = _gameBoard.GetColumn(i).ToList();
                if (ContainsNumbersOneThroughNineMoreThanOnce(column))
                {
                    return false;
                }

                var box = _gameBoard.GetBox(i).ToList();
                if (ContainsNumbersOneThroughNineMoreThanOnce(box))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Private Methods
    }
}