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

        private void StartGame(object sender, RoutedEventArgs e) // Starting game button
        {
            startbtn.Visibility = Visibility.Hidden;
            SummonGoodie(); // Goodie random position
            SummonBaddies(); // Baddies random position
            gamecanvas.Focus();

            bugsGameTimer.Tick += bugsMovement; //Bugs movement
            bugsGameTimer.Interval = TimeSpan.FromMilliseconds(10);
            bugsGameTimer.Start();

            baddiesGameTimer.Tick += baddiesChase;
            if (easyMode == false && hardMode == false) //Default normal mode
            {
                baddiesGameTimer.Interval = TimeSpan.FromMilliseconds(400); // Baddies movement
                normalbtn.Background = new SolidColorBrush(Colors.DarkCyan);
                normalbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF040422"); // turn into darksome navy
            }

            baddiesGameTimer.Start();
            started = true;

        }


        private void LostClickToPlayAgain(object sender, RoutedEventArgs e)
        {
            gamecanvas.Focus();

            playagainbutton.Visibility = Visibility.Hidden;
            Restart();

            bugsGameTimer.Start();
            baddiesGameTimer.Start();
        } //After losing press to play again

        private void WonCLickToPlayAgain(object sender, RoutedEventArgs e)//After wining press to play again
        {
            gamecanvas.Focus();

            wonbutton.Visibility = Visibility.Hidden;
            Restart();

            bugsGameTimer.Start();
            baddiesGameTimer.Start();
        }

        private void clickToContinue(object sender, RoutedEventArgs e) //Start game btn after loading saved game
        {
            if (counteBaddies == 1 || continueFromLost == -1) // if the game was saved while won btn/lost btn wasn't clicked
            {
                StartGame(sender, e);
                foreach (Rectangle baddie in baddiescontrol)
                {
                    if (baddie.Visibility == Visibility.Collapsed)
                        baddie.Visibility = Visibility.Visible;
                }
                counteBaddies = 10;
                continueFromLost = 0;
                continueBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                continueBtn.Visibility = Visibility.Hidden;
                //SummonGoodie(); // Goodie random position
                //SummonBaddies(); // Baddies random position
                gamecanvas.Focus();

                bugsGameTimer.Tick += bugsMovement; //Bugs movement
                bugsGameTimer.Interval = TimeSpan.FromMilliseconds(10);
                bugsGameTimer.Start();

                baddiesGameTimer.Tick += baddiesChase;
                if (easyMode == false && hardMode == false) //Default normal mode
                {
                    baddiesGameTimer.Interval = TimeSpan.FromMilliseconds(400); // Baddies movement
                    normalbtn.Background = new SolidColorBrush(Colors.DarkCyan);
                    normalbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF040422"); // turn into darksome navy
                }

                baddiesGameTimer.Start();
                started = true;
            }
        }
    }
}
