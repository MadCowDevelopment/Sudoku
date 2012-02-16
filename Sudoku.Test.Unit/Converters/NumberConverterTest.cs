using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku.Converters;

namespace Sudoku.Test.Unit.Converters
{
    [TestClass]
    public class NumberConverterTest
    {
        #region Fields

        private NumberConverter _converter;

        #endregion Fields

        #region Public Methods

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackIsNotImplemented()
        {
            _converter.ConvertBack(null, null, null, null);
        }

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
        public void Number10ReturnsEmptyString()
        {
            var actual = ConvertInteger(10);

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

        #endregion Public Methods

        #region Private Methods

        private object ConvertInteger(int number)
        {
            return _converter.Convert(number, typeof(string), null, CultureInfo.InvariantCulture);
        }

        #endregion Private Methods
    }
}