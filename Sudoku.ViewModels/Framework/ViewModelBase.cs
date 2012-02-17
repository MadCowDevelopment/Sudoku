using System.ComponentModel;

using Sudoku.ViewModels.Interfaces;

namespace Sudoku.ViewModels.Framework
{
    public class ViewModelBase : IViewModelBase
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Public Methods

        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Public Methods
    }
}