using System;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public abstract class SelectableToolVM : ToolVM, ISelectableToolVM
    {
        protected IGameBoardVM GameBoardVM { get; set; }

        private bool _isChecked;

        public SelectableToolVM(IGameBoardVM gameBoardVM)
        {
            GameBoardVM = gameBoardVM;
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");

                if (_isChecked)
                {
                    RaiseIsSelected(new EventArgs());
                }
            }
        }

        public event EventHandler<EventArgs> IsSelected;

        private void RaiseIsSelected(EventArgs e)
        {
            var handler = IsSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public abstract void EnterNumber(ICellVM cellVM, int number);
    }
}
