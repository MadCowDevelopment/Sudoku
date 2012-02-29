using Sudoku.Models;

namespace Sudoku.Services
{
    public interface IPuzzleGenerator
    {
        #region Methods

        IGameBoard GeneratePuzzle(Difficulty difficulty);

        #endregion Methods
    }
}