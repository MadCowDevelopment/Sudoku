using Sudoku.Injection;
using Sudoku.ViewModels.Interfaces;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            var container = new DependencyComposer();
            DataContext = container.GetExportedValue<IMainWindowVM>();
        }

        #endregion Constructors
    }
}