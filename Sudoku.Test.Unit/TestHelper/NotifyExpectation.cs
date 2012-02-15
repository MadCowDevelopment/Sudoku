using System;
using System.ComponentModel;
using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Test.Unit.TestHelper
{
    public class NotifyExpectation<T> where T : INotifyPropertyChanged
    {
        private readonly T _owner;

        private readonly string _propertyName;

        private readonly bool _eventExpected;

        internal bool EventWasRaised { get; set; }

        internal PropertyChangedEventArgs PropertyChangedEventArgs { get; set; }

        public NotifyExpectation(T owner, string propertyName, bool eventExpected)
        {
            _owner = owner;
            _propertyName = propertyName;
            _eventExpected = eventExpected;

            _owner.PropertyChanged += OwnerPropertyChanged;
        }

        private void OwnerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _propertyName)
            {
                EventWasRaised = true;
                PropertyChangedEventArgs = e;
            }

            _owner.PropertyChanged -= OwnerPropertyChanged;
        }

        public PropertyChangedEventArgs When(Action<T> action)
        {
            action(_owner);
            return PropertyChangedEventArgs;
        }

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

        internal void Assertion()
        {
            Assert.AreEqual(_eventExpected, EventWasRaised, "PropertyChanged on {0}", _propertyName);
        }
    }
}