using System.Collections.Generic;

namespace Sudoku.Models
{
    public interface IGameBoard
    {
        #region Properties

        int[] Fields
        {
            get;
        }

        #endregion Properties

        #region Methods

        Difficulty Difficulty { get; }

        IEnumerable<int> GetBox(int index);

        IEnumerable<int> GetColumn(int index);

        IEnumerable<int> GetRow(int index);

        bool IsCompleted();

        bool IsValid();

        #endregion Methods
    }
}