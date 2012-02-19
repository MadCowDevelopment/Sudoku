using System.Collections.Generic;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IToolVMFactory
    {
        List<IToolVM> CreateTools(IGameBoardVM gameBoardVM);
    }
}