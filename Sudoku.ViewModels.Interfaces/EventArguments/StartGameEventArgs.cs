using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces.EventArguments
{
    public class StartGameEventArgs : System.EventArgs
    {
        #region Constructors

        public StartGameEventArgs(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }

        #endregion Constructors

        #region Public Properties

        public Difficulty Difficulty
        {
            get; private set;
        }

        #endregion Public Properties
    }
}