using System.Globalization;
using System.Windows;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Converters;

namespace Sudoku.Test.Unit.Converters
{
    [TestClass]
    public class NumberVisibilityConverterTest
    {
        private NumberVisibilityConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new NumberVisibilityConverter();
        }

        [TestMethod]
        public void Number0ReturnsCollapsed()
        {
            var actual = ConvertValue(0);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void Number1ReturnsVisible()
        {
            var actual = ConvertValue(1);

            Assert.AreEqual(Visibility.Visible, actual);
        }

        [TestMethod]
        public void Number9ReturnsVisible()
        {
            var actual = ConvertValue(9);

            Assert.AreEqual(Visibility.Visible, actual);
        }

        [TestMethod]
        public void Number10ReturnsCollapsed()
        {
            var actual = ConvertValue(10);

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        [TestMethod]
        public void ValueThatCannotBeConvertedToIntReturnsCollapsed()
        {
            var actual = ConvertValue("BLA");

            Assert.AreEqual(Visibility.Collapsed, actual);
        }

        private object ConvertValue(object value)
        {
            return _converter.Convert(value, typeof(Visibility), null, CultureInfo.InvariantCulture);
        }
    }
}
