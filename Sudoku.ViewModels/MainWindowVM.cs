using System;
using System.ComponentModel.Composition;

using Sudoku.Test.Unit.ViewModels;
using Sudoku.ViewModels.Framework;
using Sudoku.ViewModels.Interfaces;
using Sudoku.ViewModels.Interfaces.EventArguments;

namespace Sudoku.ViewModels
{
    [Export(typeof(IMainWindowVM))]
    public class MainWindowVM : ViewModelBase, IMainWindowVM
    {
        #region Fields

        private readonly IGameVMFactory _gameVMFactory;
        private readonly IMenuVM _menuVM;

        private IGameVM _gameVM;

        private readonly IGameOverVM _gameOverVM;

        private IViewModelBase _content;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public MainWindowVM(IMenuVM menuVM, IGameOverVM gameOverVM, IGameVMFactory gameVMFactory)
        {
            _menuVM = menuVM;
            _menuVM.StartGameRequested += MenuVMStartGameRequested;

            _gameOverVM = gameOverVM;
            _gameOverVM.MenuRequested += GameOverVMMenuRequested;
            _gameVMFactory = gameVMFactory;
            
            Content = _menuVM;
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

        #region Private Methods

        private void MenuVMStartGameRequested(object sender, StartGameEventArgs e)
        {
            _gameVM = _gameVMFactory.CreateInstance(e.Difficulty);
            _gameVM.GameCompleted += GameVMGameCompleted;
            
            Content = _gameVM;
        }

        private void GameVMGameCompleted(object sender, EventArgs e)
        {
            _gameVM.GameCompleted -= GameVMGameCompleted;
            _gameVM = null;
            Content = _gameOverVM;
        }

        private void GameOverVMMenuRequested(object sender, EventArgs e)
        {
            Content = _menuVM;
        }

        #endregion Private Methods
    }
}