using Sudoku.Models;

namespace Sudoku.Services
{
    public interface IPuzzleGenerator
    {
        void GeneratePuzzle(GameBoard gameBoard, Difficulty difficulty);
    }
}