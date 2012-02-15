using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Sudoku.Test.Unit.TestHelper
{
    public class NotifyExpectationList<T> where T : INotifyPropertyChanged
    {
        private readonly T _owner;

        private readonly List<NotifyExpectation<T>> _expectations;

        public NotifyExpectationList(T owner, IEnumerable<NotifyExpectation<T>> expectations)
        {
            _owner = owner;
            _expectations = expectations.ToList();
        }

        public IEnumerable<PropertyChangedEventArgs> When(Action<T> action)
        {
            action(_owner);

            var eventArgs = new List<PropertyChangedEventArgs>();

            foreach (var expectation in _expectations)
            {
                expectation.Assertion();
                var args = expectation.PropertyChangedEventArgs;
                eventArgs.Add(args);
            }

            return eventArgs;
        }

        public NotifyExpectationList<T> And<TProperty>(Expression<Func<T, TProperty>> func)
        {
            var expectation = _owner.RaisesPropertyChanged(func);
            _expectations.Add(expectation);
            return new NotifyExpectationList<T>(_owner, _expectations);
        }

        public NotifyExpectationList<T> AndNot<TProperty>(Expression<Func<T, TProperty>> func)
        {
            var expectation = _owner.DoesNotRaisePropertyChanged(func);
            _expectations.Add(expectation);
            return new NotifyExpectationList<T>(_owner, _expectations);
        }
    }
}