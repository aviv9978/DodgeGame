using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.IO;


namespace NewGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() // starting Lobby
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new Lobby(this));
        }

        public void GameNevigate() // nevigate to gameself xaml
        {
            _NavigationFrame.Navigate(new Uri("gameself.xaml", UriKind.Relative));
        }

        private void minimizeClick(object sender, RoutedEventArgs e) // minimize btn in header
        {
            this.WindowState = WindowState.Minimized;

        }

        private void maximizeClick(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
                case WindowState.Minimized:
                    break;
            }
        } // maximize btn in header

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        } // allow to drag window

        private void ReturnToLobby(object sender, RoutedEventArgs e) // return to lobby btn in header
        {
            _NavigationFrame.Navigate(new Lobby(this));
        }

        private void closeClick(object sender, RoutedEventArgs e) // button close header (X)
        {
            this.Close();
        }
    }
}
