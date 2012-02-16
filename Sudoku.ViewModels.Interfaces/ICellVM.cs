namespace Sudoku.ViewModels.Interfaces
{
    public interface ICellVM : IViewModelBase
    {
        #region Properties

        bool IsSelected
        {
            get; set;
        }

        int Number
        {
            get; set;
        }

        #endregion Properties
    }
}