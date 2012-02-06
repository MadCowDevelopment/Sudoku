namespace Sudoku.ViewModels
{
    public class CellViewModel : ViewModelBase
    {
        #region Fields

        private int _selectedNumber;

        #endregion Fields

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