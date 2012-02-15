namespace Sudoku.ViewModels.Interfaces
{
    public interface ICellVM : IViewModelBase
    {
        int Number { get; set; }

        bool IsSelected { get; set; }
    }
}