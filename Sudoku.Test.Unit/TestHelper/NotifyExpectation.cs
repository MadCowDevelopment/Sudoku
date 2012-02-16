using System;
using System.ComponentModel;
using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Test.Unit.TestHelper
{
    public class NotifyExpectation<T>
        where T : INotifyPropertyChanged
    {
        #region Fields

        private readonly bool _eventExpected;
        private readonly T _owner;
        private readonly string _propertyName;

        #endregion Fields

        #region Constructors

        public NotifyExpectation(T owner, string propertyName, bool eventExpected)
        {
            _owner = owner;
            _propertyName = propertyName;
            _eventExpected = eventExpected;

            _owner.PropertyChanged += OwnerPropertyChanged;
        }

        #endregion Constructors

        #region Internal Properties

        internal bool EventWasRaised
        {
            get; set;
        }

        internal PropertyChangedEventArgs PropertyChangedEventArgs
        {
            get; set;
        }

        #endregion Internal Properties

        #region Public Methods

        public NotifyExpectationList<T> And<TProperty>(Expression<Func<T, TProperty>> func)
        {
            var expectation = _owner.RaisesPropertyChanged(func);
            return new NotifyExpectationList<T>(_owner, new[] { this, expectation  });
        }

        public NotifyExpectationList<T> AndNot<TProperty>(Expression<Func<T, TProperty>> func)
        {
            var expectation = _owner.DoesNotRaisePropertyChanged(func);
            return new NotifyExpectationList<T>(_owner, new[] { this, expectation });
        }

        public PropertyChangedEventArgs When(Action<T> action)
        {
            action(_owner);
            return PropertyChangedEventArgs;
        }

        #endregion Public Methods

        #region Internal Methods

        internal void Assertion()
        {
            Assert.AreEqual(_eventExpected, EventWasRaised, "PropertyChanged on {0}", _propertyName);
        }

        #endregion Internal Methods

        #region Private Methods

        private void OwnerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _propertyName)
            {
                EventWasRaised = true;
                PropertyChangedEventArgs = e;
            }

            _owner.PropertyChanged -= OwnerPropertyChanged;
        }

        #endregion Private Methods
    }
}