﻿using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class PencilToolVM : SelectableToolVM, IPencilToolVM
    {
        public PencilToolVM(IGameBoardVM gameBoardVM)
            : base(gameBoardVM)
        {
            Image = @"..\Images\Pencil.png";
        }

        public override void EnterNumber(ICellVM cellVM, int number)
        {
            // TODO: remove pencil marks from other cells
        }
    }
}