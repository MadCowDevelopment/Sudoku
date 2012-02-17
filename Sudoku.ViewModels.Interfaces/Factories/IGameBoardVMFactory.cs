using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IGameBoardVMFactory
    {
        IGameBoardVM CreateInstance(Difficulty difficulty);
    }
}
