using System;

namespace Sudoku.ViewModels
{
    public class NumberEnteredEventArgs : EventArgs
    {
        public CellVM Cell { get; set; }

        public int Number { get; private set; }

        public NumberEnteredEventArgs(CellVM cell, int number)
        {
            Cell = cell;
            Number = number;
        }
    }
}