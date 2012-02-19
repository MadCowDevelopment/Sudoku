using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

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

        private readonly IGameBoard _gameBoard;

        private ICellVM _selectedCell;

        #endregion Fields

        #region Constructors

        public GameBoardVM(IGameBoard gameboard, IEnumerable<ICellVM> cells)
        {
            _gameBoard = gameboard;
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
                return _gameBoard.IsCompleted();
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

        #region Public Methods

        public IEnumerable<IChangeableCellVM> GetChangeableCellsThatDontHaveANumberSet()
        {
            return Cells.OfType<IChangeableCellVM>().Where(p => p.Number == 0);
        }

        public IEnumerable<int> GetNumbersInSameBox(int boxIndex)
        {
            return _gameBoard.GetBox(boxIndex);
        }

        public IEnumerable<int> GetNumbersInSameColumn(int columnIndex)
        {
            return _gameBoard.GetColumn(columnIndex);
        }

        public IEnumerable<int> GetNumbersInSameRow(int rowIndex)
        {
            return _gameBoard.GetRow(rowIndex);
        }

        #endregion Public Methods

        #region Private Methods

        private void CellVMNumberChanged(object sender, NumberChangedEventArgs e)
        {
            var cell = (ICellVM)sender;
            _gameBoard.Fields[cell.Index] = e.Number;
        }

        #endregion Private Methods
    }
}