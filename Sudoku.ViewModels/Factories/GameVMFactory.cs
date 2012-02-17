using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IGameVMFactory))]
    public class GameVMFactory : IGameVMFactory
    {
        private readonly IGameBoardVMFactory _gameBoardVMFactory;

        [ImportingConstructor]
        public GameVMFactory(IGameBoardVMFactory gameBoardVMFactory)
        {
            _gameBoardVMFactory = gameBoardVMFactory;            
        }

        public IGameVM CreateInstance(Difficulty difficulty)
        {
            var gameBoardVM = _gameBoardVMFactory.CreateInstance(difficulty);

            var penTool = new PenToolVM(gameBoardVM);
            var pencilTool = new PencilToolVM(gameBoardVM);
            var tools = new List<IToolVM> { penTool, pencilTool };
            var gameVM = new GameVM(gameBoardVM, tools);

            return gameVM;
        }
    }
}