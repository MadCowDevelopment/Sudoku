using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels
{
    public abstract class CellVM : ViewModelBase, ICellVM
    {
        #region Fields

        private bool _isSelected;
        private int _number;

        #endregion Fields

        #region Constructors

        protected CellVM(int actualValue)
        {
            Number = actualValue;
        }

        #endregion Constructors

        #region Public Properties

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
            }
        }

        #endregion Public Properties
    }
}