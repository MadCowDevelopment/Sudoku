using System;
using System.Globalization;
using System.Windows.Data;

namespace Sudoku.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intValue = (int)value;

            if (intValue < 1 || intValue > 9)
            {
                return string.Empty;
            }

            return intValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
