using System;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.Factories;
using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public abstract class SelectableToolVM : ToolVM, ISelectableToolVM
    {
        #region Fields

        private bool _isChecked;

        #endregion Fields

        #region Constructors

        public SelectableToolVM(IGameBoardVM gameBoardVM)
        {
            GameBoardVM = gameBoardVM;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<EventArgs> IsSelected;

        #endregion Events

        #region Public Properties

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

        #endregion Public Properties

        #region Protected Properties

        protected IGameBoardVM GameBoardVM
        {
            get; set;
        }

        #endregion Protected Properties

        #region Public Methods

        public abstract void EnterNumber(ICellVM cellVM, int number);

        #endregion Public Methods

        #region Private Methods

        private void RaiseIsSelected(EventArgs e)
        {
            var handler = IsSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Private Methods
    }
}