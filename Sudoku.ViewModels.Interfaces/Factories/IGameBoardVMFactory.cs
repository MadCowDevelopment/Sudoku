using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IGameBoardVMFactory
    {
        #region Methods

        IGameBoardVM CreateInstance(Difficulty difficulty);

        #endregion Methods
    }
}