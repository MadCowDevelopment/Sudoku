using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameBoardVMFactory
    {
        IGameBoardVM CreateInstance(Difficulty difficulty);
    }
}
