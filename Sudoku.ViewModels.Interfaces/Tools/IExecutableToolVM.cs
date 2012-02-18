using System.Windows.Input;

namespace Sudoku.ViewModels.Interfaces.Tools
{
    public interface IExecutableToolVM : IToolVM
    {
        #region Properties

        ICommand ExecuteCommand
        {
            get;
        }

        #endregion Properties
    }
}