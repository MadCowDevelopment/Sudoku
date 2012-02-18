using System.ComponentModel.Composition;

using Sudoku.ViewModels.Interfaces.Tools;

namespace Sudoku.ViewModels.Tools
{
    [Export(typeof(IPencilAllToolVM))]
    public class PencilAllToolVM : ExecutableToolVM, IPencilAllToolVM
    {
        public PencilAllToolVM()
        {
            Image = @"..\Images\PencilAll.png";
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void OnExecute()
        {
            return;
        }
    }
}
