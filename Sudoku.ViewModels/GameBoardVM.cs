using System;
using System.Collections.Generic;
using System.Windows.Input;

using Sudoku.Models;

namespace Sudoku.ViewModels
{
    public class GameBoardVM : ViewModelBase
    {
        public GameBoardVM(GameBoard gameBoard)
        {
            Cells = new List<CellVM>();

            foreach (var value in gameBoard.Fields)
            {
                if (value != 0)
                {
                    Cells.Add(new FixedCellVM(value));
                }
                else
                {
                    var cell = new ChangeableCellVM();
                    Cells.Add(cell);
                }
            }
        }

        public List<CellVM> Cells { get; private set; }

        private ICommand _enterNumberCommand;


        public ICommand EnterNumberCommand
        {
            get
            {
                return _enterNumberCommand ?? (_enterNumberCommand = new RelayCommand(OnNumberEntered));
            }
        }

        private CellVM _selectedCell;

        public CellVM SelectedCell
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

        private void OnNumberEntered(object obj)
        {
            if (SelectedCell is ChangeableCellVM)
            {
                var number = int.Parse(obj.ToString());
                SelectedCell.Number = SelectedCell.Number == number ? 0 : number;

                // TODO: adjust pencil marks
            }
        }
    }
}
