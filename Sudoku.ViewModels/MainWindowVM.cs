namespace Sudoku.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private ViewModelBase _content;

        public MainWindowVM()
        {
            Content = new GameBoardViewModel();
        }

        public ViewModelBase Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
                RaisePropertyChanged("Content");
            }
        }
    }
}