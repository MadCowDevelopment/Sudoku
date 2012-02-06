using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Models
{
    public class GameBoard
    {
        #region Constructors

        public GameBoard()
        {
            Fields = new int[81];

            for (int i = 0; i < 81; i++)
            {
                Fields[i] = 0;
            }
        }

        #endregion Constructors

        #region Public Properties

        public int[] Fields
        {
            get; set;
        }

        #endregion Public Properties

        #region Public Methods

        public IEnumerable<int> GetBox(int index)
        {
            var result = Fields.Skip(index * 3).Take(3).ToList();
            result.AddRange(Fields.Skip((index * 3) + 9).Take(3));
            result.AddRange(Fields.Skip((index * 3) + 18).Take(3));
            return result;
        }

        public IEnumerable<int> GetColumn(int index)
        {
            return Fields.Where((p, i) => i % 9 == index);
        }

        public IEnumerable<int> GetRow(int index)
        {
            return Fields.Skip(index * 9).Take(9);
        }

        #endregion
    }
}