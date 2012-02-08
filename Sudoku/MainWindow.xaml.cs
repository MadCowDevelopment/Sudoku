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

            var sudokuGenerator = new SudokuGenerator();
            var puzzleGenerator = new PuzzleGenerator();
            DataContext = new MainWindowVM(sudokuGenerator, puzzleGenerator);
        }

        #endregion Constructors
    }
}