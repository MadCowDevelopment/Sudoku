using Sudoku.Models;

namespace Sudoku.Services
{
    public interface ISudokuGenerator
    {
        GameBoard GeneratePuzzle();
    }
}