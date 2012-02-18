using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IToolVMFactory))]
    public class ToolVMFactory : IToolVMFactory
    {
        public List<IToolVM> CreateTools(IGameBoardVM gameBoardVM)
        {
            var penTool = new PenToolVM(gameBoardVM);
            var pencilTool = new PencilToolVM(gameBoardVM);
            var tools = new List<IToolVM> { penTool, pencilTool };

            return tools;
        }
    }
}
