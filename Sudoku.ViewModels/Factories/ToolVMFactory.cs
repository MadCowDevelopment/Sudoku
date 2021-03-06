﻿using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;
using Sudoku.ViewModels.Tools;

namespace Sudoku.ViewModels.Factories
{
    [Export(typeof(IToolVMFactory))]
    public class ToolVMFactory : IToolVMFactory
    {
        #region Public Methods

        public List<IToolVM> CreateTools(IGameBoardVM gameBoardVM)
        {
            var penTool = new PenToolVM(gameBoardVM);
            var pencilTool = new PencilToolVM(gameBoardVM);
            var pencilAllTool = new PencilAllToolVM(gameBoardVM);
            var tools = new List<IToolVM> { penTool, pencilTool, pencilAllTool };

            return tools;
        }

        #endregion Public Methods
    }
}