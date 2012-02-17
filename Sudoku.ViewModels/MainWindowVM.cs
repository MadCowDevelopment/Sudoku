using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels
{
    [Export(typeof(IMainWindowVM))]
    public class MainWindowVM : ViewModelBase, IMainWindowVM
    {
        private readonly IMenuVM _menuVM;

        private readonly IGameVMFactory _gameVMFactory;

        #region Fields

        private IViewModelBase _content;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public MainWindowVM(IMenuVM menuVM, IGameVMFactory gameVMFactory)
        {
            _menuVM = menuVM;
            _gameVMFactory = gameVMFactory;
            _menuVM.StartGameRequested += MenuVMStartGameRequested;  

            Content = _menuVM;
        }

        private void MenuVMStartGameRequested(object sender, StartGameEventArgs e)
        {
            
            Content = _gameVMFactory.CreateInstance(e.Difficulty);
        }

        #endregion Constructors

        #region Public Properties

        public IViewModelBase Content
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

        #endregion Public Properties
    }
}