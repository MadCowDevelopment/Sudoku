using System;

using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels
{
    public abstract class CellVM : ViewModelBase, ICellVM
    {
        #region Fields

        private bool _isSelected;
        private int _number;

        #endregion Fields

        #region Constructors

        protected CellVM(int index, int actualValue)
        {
            Index = index;
            Number = actualValue;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<NumberChangedEventArgs> NumberChanged;

        #endregion Events

        #region Public Properties

        public int Index
        {
            get; private set;
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                RaisePropertyChanged("Number");
                RaiseNumberChanged(new NumberChangedEventArgs(_number));
            }
        }

        #endregion Public Properties

        #region Private Methods

        private void RaiseNumberChanged(NumberChangedEventArgs e)
        {
            var handler = NumberChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Private Methods
    }
}