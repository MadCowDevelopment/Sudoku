using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Converters;

namespace Sudoku.Test.Unit.Converters
{
    [TestClass]
    public class NumberConverterTest
    {
        private NumberConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new NumberConverter();
        }

        [TestMethod]
        public void Number0ReturnsEmptyString()
        {
            var actual = ConvertInteger(0);

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Number1Returns1()
        {
            var actual = ConvertInteger(1);

            Assert.AreEqual("1", actual);
        }

        [TestMethod]
        public void Number9Returns9()
        {
            var actual = ConvertInteger(9);

            Assert.AreEqual("9", actual);
        }

        [TestMethod]
        public void Number10ReturnsEmptyString()
        {
            var actual = ConvertInteger(10);

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackIsNotImplemented()
        {
            _converter.ConvertBack(null, null, null, null);
        }

        private object ConvertInteger(int number)
        {
            return _converter.Convert(number, typeof(string), null, CultureInfo.InvariantCulture);
        }
    }
}
