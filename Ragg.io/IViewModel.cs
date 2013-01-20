using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Ragg.io
{
    public interface IViewModel<T> where T : FrameworkElement
    {
        T View { get; }
    }
}
