using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces.EventArguments
{
    public class StartGameEventArgs : System.EventArgs
    {
        public Difficulty Difficulty { get; private set; }

        public StartGameEventArgs(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }
    }
}