using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sudoku.Converters
{
    public class NumberVisibilityConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue;

            if (!Int32.TryParse(value.ToString(), out intValue))
            {
                return Visibility.Collapsed;
            }

            if (intValue < 1 || intValue > 9)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}