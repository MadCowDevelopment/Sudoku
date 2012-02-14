namespace Sudoku.ViewModels
{
    public abstract class CellVM : ViewModelBase
    {
        #region Fields

        private int _number;

        private bool _isSelected;

        #endregion Fields

        protected CellVM(int actualValue)
        {
            Number = actualValue;
        }

        #region Public Properties

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

        #endregion Public Properties
    }
}