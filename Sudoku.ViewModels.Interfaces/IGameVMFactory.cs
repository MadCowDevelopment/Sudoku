using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameVMFactory
    {
        IGameVM CreateInstance(Difficulty difficulty);
    }
}
