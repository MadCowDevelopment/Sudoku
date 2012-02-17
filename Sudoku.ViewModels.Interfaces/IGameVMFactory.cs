using Sudoku.Models;

namespace Sudoku.ViewModels.Interfaces
{
    public interface IGameVMFactory
    {
        #region Methods

        IGameVM CreateInstance(Difficulty difficulty);

        #endregion Methods
    }
}