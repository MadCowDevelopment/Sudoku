using System.Collections.Generic;

namespace Sudoku.ViewModels.Interfaces.Factories
{
    public interface IGameBoardVM : IViewModelBase
    {
        #region Properties

        List<ICellVM> Cells
        {
            get;
        }

        bool IsCompleted
        {
            get;
        }

        ICellVM SelectedCell
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        void DisablePencilMarksForNumberInBox(int number, int boxIndex);

        void DisablePencilMarksForNumberInColumn(int number, int columnIndex);

        void DisablePencilMarksForNumberInRow(int number, int rowIndex);

        IEnumerable<IChangeableCellVM> GetAllChangeableCellsThatDontHaveANumberSet();

        IEnumerable<int> GetNumbersInSameBox(int boxIndex);

        IEnumerable<int> GetNumbersInSameColumn(int columnIndex);

        IEnumerable<int> GetNumbersInSameRow(int rowIndex);

        #endregion Methods
    }
}