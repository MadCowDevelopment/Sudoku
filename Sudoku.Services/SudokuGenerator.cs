using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Sudoku.Models;

namespace Sudoku.Services
{
    [Export(typeof(ISudokuGenerator))]
    public class SudokuGenerator : ISudokuGenerator
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        private GameBoard _gameBoard;

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

                if (_gameBoard.IsValid())
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

        #endregion Private Methods
    }
}