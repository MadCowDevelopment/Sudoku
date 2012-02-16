using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    public class ToolVM : ViewModelBase, IToolVM
    {
        #region Public Properties

        public string Image
        {
            get; protected set;
        }

        #endregion Public Properties
    }
}