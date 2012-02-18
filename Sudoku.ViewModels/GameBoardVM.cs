using System.Collections.Generic;
using System.ComponentModel.Composition;

using Sudoku.Models;
using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;
using Sudoku.ViewModels.Interfaces.Factories;

namespace Sudoku.ViewModels
{
    [Export(typeof(IGameBoardVM))]
    public class GameBoardVM : ViewModelBase, IGameBoardVM
    {
        #region Fields

        private readonly IGameBoard _gameboard;

        private ICellVM _selectedCell;

        #endregion Fields

        #region Constructors

        public GameBoardVM(IGameBoard gameboard, IEnumerable<ICellVM> cells)
        {
            _gameboard = gameboard;
            Cells = new List<ICellVM>(cells);

            foreach (var cellVM in Cells)
            {
                cellVM.NumberChanged += CellVMNumberChanged;
            }
        }

        #endregion Constructors

        #region Public Properties

        public List<ICellVM> Cells
        {
            get; private set;
        }

        public bool IsCompleted
        {
            get
            {
                return _gameboard.IsCompleted();
            }
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

        #region Private Methods

        private void CellVMNumberChanged(object sender, NumberChangedEventArgs e)
        {
            var cell = (ICellVM)sender;
            _gameboard.Fields[cell.Index] = e.Number;
        }

        #endregion Private Methods
    }
}