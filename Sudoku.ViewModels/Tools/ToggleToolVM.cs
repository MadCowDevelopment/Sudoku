using System;

namespace Sudoku.ViewModels.Tools
{
    public abstract class ToggleToolVM : ToolVM
    {
        protected GameBoardVM GameBoardVM { get; set; }

        private bool _isChecked;

        public ToggleToolVM(GameBoardVM gameBoardVM)
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

        public abstract void EnterNumber(CellVM cellVM, int number);
    }
}
