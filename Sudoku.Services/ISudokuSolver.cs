namespace Sudoku.Services
{
    public interface ISudokuSolver
    {
        #region Methods

        int Solve(int[][] fields);

        #endregion Methods
    }
}