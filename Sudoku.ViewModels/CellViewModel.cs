namespace Sudoku.ViewModels
{
    public class CellViewModel : ViewModelBase
    {
        private readonly int _actualValue;

        #region Fields

        private int _selectedNumber;

        #endregion Fields

        public CellViewModel(int actualValue)
        {
            SelectedNumber = actualValue;
        }

        #region Public Properties

        public int SelectedNumber
        {
            get
            {
                return _selectedNumber;
            }

            set
            {
                _selectedNumber = value;
                RaisePropertyChanged("SelectedNumber");
            }
        }

        #endregion Public Properties
    }
}