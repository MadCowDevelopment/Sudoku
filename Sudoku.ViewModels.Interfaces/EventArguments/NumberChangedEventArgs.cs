using System;

namespace Sudoku.ViewModels.Interfaces.EventArguments
{
    public class NumberChangedEventArgs : EventArgs
    {
        #region Constructors

        public NumberChangedEventArgs(int number)
        {
            Number = number;
        }

        #endregion Constructors

        #region Public Properties

        public int Number
        {
            get; private set;
        }

        #endregion Public Properties
    }
}