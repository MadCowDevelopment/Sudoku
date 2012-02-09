using System;

namespace Sudoku.ViewModels
{
    public class NumberEnteredEventArgs : EventArgs
    {
        public int Number { get; private set; }

        public NumberEnteredEventArgs(int number)
        {
            Number = number;
        }
    }
}