namespace Sudoku.ViewModels.Interfaces
{
    public interface IMainWindowVM : IViewModelBase
    {
        #region Properties

        IViewModelBase Content
        {
            get; set;
        }

        #endregion Properties
    }
}