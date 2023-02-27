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
using System.Security.Cryptography;
using System.Diagnostics;
using Path = System.IO.Path;

namespace NewGame
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Page
    {
        public MainWindow mainWindow;
        string defaultFolder;
        string newpath;
        public Lobby(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory; // debug folder
            newpath = Path.GetFullPath(Path.Combine(defaultFolder, @"..\..\Saves")); // Saves folder
            LoadSaveInComboBox(); // check newpath - add saves files to comboBoxItem


            GameWindow gameWindow = new GameWindow();
            gameWindow.savedGame = false;
        }


        private void Newgame_Click(object sender, RoutedEventArgs e) // New game button
        {
           this.mainWindow.GameNevigate(); // Nevigate to game xaml
        }

        private void exitClick1(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        } // Exit button in menu

        private void LoadSaveInComboBox() // Load from saves - show in ComboBoxItem
        {
            var saves = Directory.GetFiles(newpath, "*.save*");
            foreach (var save in saves)
            {
                string[] parts = save.Split('\\');
                ComboBoxItem item = new ComboBoxItem();
                item.Content = parts[parts.Length - 1];
                myCombo.Items.Add(item);

            }

        }

        private void ClickToPlayLoadGame(object sender, RoutedEventArgs e) // Click Button to play a load game from file
        {
            //MainWindow newLoadGame = new MainWindow(item.Content.ToString());
            if (myCombo.SelectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)myCombo.SelectedItem;
                string pathCombined = Path.GetFullPath(Path.Combine(defaultFolder, @"..\..\Saves", item.Content.ToString()));
                this.mainWindow._NavigationFrame.Navigate(new GameWindow(pathCombined));
            }
        }


    }
}
