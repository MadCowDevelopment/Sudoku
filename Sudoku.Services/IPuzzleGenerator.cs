using Sudoku.Models;

namespace Sudoku.Services
{
    public interface IPuzzleGenerator
    {
        #region Methods

        void GeneratePuzzle(GameBoard gameBoard, Difficulty difficulty);

        #endregion Methods
    }
}