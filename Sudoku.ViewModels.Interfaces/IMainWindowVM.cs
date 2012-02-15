namespace Sudoku.ViewModels.Interfaces
{
    public interface IMainWindowVM : IViewModelBase
    {
        IViewModelBase Content { get; set; }
    }
}