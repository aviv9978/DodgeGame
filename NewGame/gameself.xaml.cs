using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Diagnostics;
using System.IO;

namespace NewGame
{
    public partial class GameWindow : Page
    {
        private DispatcherTimer bugsGameTimer = new DispatcherTimer(); //Bugs timer
        private DispatcherTimer baddiesGameTimer = new DispatcherTimer(); //Baddies timer
        private Rectangle[] baddiescontrol;
        string loadFilePath;
        public  bool savedGame { get; set; }


        public GameWindow() // creating game with 10 baddies and check first game or saved
        {
            InitializeComponent();
            baddiescontrol = new Rectangle[] { baddie1, baddie2, baddie3, baddie4, baddie5, baddie6, baddie7, baddie8, baddie9, baddie10 };
            FirstOrContinueBtn();
            this.savedGame = false;
        }
        public GameWindow(string filePath) // Loading game from saves
        {
             loadFilePath = filePath;
            InitializeComponent();
            this.savedGame = true;
            baddiescontrol = new Rectangle[] { baddie1, baddie2, baddie3, baddie4, baddie5, baddie6, baddie7, baddie8, baddie9, baddie10 };
            ReadDataFromSave(filePath);
            FirstOrContinueBtn();
            loses.Text = $">Lost: {countLose}";
            wins.Text = $">Won: {countWin}";
        }


        public void FirstOrContinueBtn() // first game or saved game for start button
        {

            if (this.savedGame == false)
                startbtn.Visibility = Visibility.Visible;
            else continueBtn.Visibility = Visibility.Visible;
        }


    }
}

