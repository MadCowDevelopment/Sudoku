using Sudoku.Models;

namespace Sudoku.Services
{
    public interface ISudokuGenerator
    {
        #region Methods

        GameBoard GeneratePuzzle();

        #endregion Methods
    }
}