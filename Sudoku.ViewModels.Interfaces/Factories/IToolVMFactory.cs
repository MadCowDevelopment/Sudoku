using System.Collections.Generic;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IToolVMFactory
    {
        #region Methods

        List<IToolVM> CreateTools(IGameBoardVM gameBoardVM);

        #endregion Methods
    }
}