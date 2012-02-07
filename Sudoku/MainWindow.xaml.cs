using Sudoku.Services;
using Sudoku.ViewModels;

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

            var generator = new SudokuGenerator();
            DataContext = new MainWindowVM(generator);
        }

        #endregion Constructors
    }
}