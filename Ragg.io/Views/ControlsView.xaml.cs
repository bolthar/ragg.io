using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ragg.io.Views
{
    /// <summary>
    /// Interaction logic for ControlsView.xaml
    /// </summary>
    public partial class ControlsView : UserControl
    {
        public event Action<int> ChangeMultiplier;
        public event Action<bool> AddGame;

        public ControlsView()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeMultiplier(2);
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeMultiplier(3);
        }

        private void ToggleButton_Click_2(object sender, RoutedEventArgs e)
        {
            ChangeMultiplier(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGame(true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddGame(false);
        }
    }
}
