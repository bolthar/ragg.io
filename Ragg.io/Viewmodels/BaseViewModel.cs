using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Linq.Expressions;
using System.Reflection;

namespace Ragg.io.Viewmodels
{
    public abstract class BaseViewModel<TV> : IViewModel<TV> , INotifyPropertyChanged where TV : FrameworkElement
    {
        private TV _view;

        public TV View
        {
            get { return _view; }
        }

        public BaseViewModel(TV view)
        {
            _view = view;
            _view.DataContext = this;
        }

        protected void Notify<T>(Expression<Func<T>> expr)
        {
            PropertyChanged.Raise(expr);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}