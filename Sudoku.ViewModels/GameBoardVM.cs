using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.ViewModels
{
    [Export(typeof(IGameBoardVM))]
    public class GameBoardVM : ViewModelBase, IGameBoardVM
    {
        #region Fields

        private ICellVM _selectedCell;

        #endregion Fields

        #region Constructors

        public GameBoardVM(IEnumerable<ICellVM> cells)
        {
            Cells = new List<ICellVM>(cells);
        }

        #endregion Constructors

        #region Public Properties

        public List<ICellVM> Cells
        {
            get; private set;
        }

        public ICellVM SelectedCell
        {
            get
            {
                return _selectedCell;
            }

            set
            {
                _selectedCell = value;
                RaisePropertyChanged("SelectedCell");
            }
        }

        #endregion Public Properties
    }
}