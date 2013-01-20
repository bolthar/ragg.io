using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Ragg.io.Viewmodels;
using Ragg.io.Views;
using Ragg.io.Models;

namespace Ragg.io
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IGame firstGame = new NoPreviousGame();
            Player one = new Player("one");
            Player two = new Player("two");
            Player three = new Player("three");
            Player four = new Player("four");
            Player five = new Player("five");
            Player six = new Player("six");
            new ShellViewModel(new ShellView()).View.Show();
        }
    }
}
