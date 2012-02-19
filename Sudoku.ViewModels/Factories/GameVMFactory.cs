using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IGameVMFactory))]
    public class GameVMFactory : IGameVMFactory
    {
        #region Fields

        private readonly IGameBoardVMFactory _gameBoardVMFactory;
        private readonly IToolVMFactory _toolVMFactory;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public GameVMFactory(IGameBoardVMFactory gameBoardVMFactory, IToolVMFactory toolVMFactory)
        {
            _gameBoardVMFactory = gameBoardVMFactory;
            _toolVMFactory = toolVMFactory;
        }

        #endregion Constructors

        #region Public Methods

        public IGameVM CreateInstance(Difficulty difficulty)
        {
            var gameBoardVM = _gameBoardVMFactory.CreateInstance(difficulty);
            var tools = _toolVMFactory.CreateTools(gameBoardVM);

            var gameVM = new GameVM(gameBoardVM, tools);

            return gameVM;
        }

        #endregion Public Methods
    }
}