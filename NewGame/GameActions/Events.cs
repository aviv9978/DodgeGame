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
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace NewGame
{
    partial class GameWindow
    {
        public int counteBaddies = 10;
        public int countWin = 0;
        public int countLose = 0;
        int continueFromLost = 0; // -1 for continue save from lost button 0 for conitnue from middle of game
        private void Collisions() // Colission between baddies to goodie and baddies to baddies
        {
            foreach (Rectangle baddie in baddiescontrol)
            {
                baddie.Stroke = Brushes.Black;
                Rect bugsHitBox = new Rect(Canvas.GetLeft(bugs), Canvas.GetTop(bugs), bugs.Width, bugs.Height);
                Rect baddieHitBox = new Rect(Canvas.GetLeft(baddie), Canvas.GetTop(baddie), baddie.Width, baddie.Height);

                if (bugsHitBox.IntersectsWith(baddieHitBox) && baddie.Visibility != Visibility.Collapsed) // between baddie to goodie
                {
                    bugsGameTimer.Stop();
                    baddiesGameTimer.Stop();
                    playagainbutton.Visibility = Visibility.Visible;
                    counteBaddies = 10;
                    started = false;
                    countLose++;
                    loses.Text = $">Lost: {countLose}";
                    continueFromLost = -1; // if saving while play again button shows,
                                           // -1 means the game was already lost and when continue it start new one
                }

                else foreach (Rectangle otherbaddie in baddiescontrol) // between baddies to baddies
                    {
                        if (otherbaddie != baddie && otherbaddie.Visibility != Visibility.Collapsed)
                        {
                            Rect otherBaddieHitBox = new Rect(Canvas.GetLeft(otherbaddie), Canvas.GetTop(otherbaddie), otherbaddie.Width, otherbaddie.Height);
                            if (otherBaddieHitBox.IntersectsWith(baddieHitBox) && baddie.Visibility != Visibility.Collapsed)
                            {
                                otherbaddie.Visibility = Visibility.Collapsed;
                                counteBaddies--;
                            }

                        }
                    }
            }
        }
        private void CheckIfGameWon() // game won when 1 baddie left
        {
            if (counteBaddies == 1)
            {
                bugsGameTimer.Stop();
                baddiesGameTimer.Stop();
                wonbutton.Visibility = Visibility.Visible;
                started = false;
                countWin++;
                wins.Text = $">Won: {countWin}";
            }
        }
        private void Restart() // restart game so every baddie returns and random positions
        {
            foreach (Rectangle baddie in baddiescontrol)
            {
                if (baddie.Visibility == Visibility.Collapsed)
                    baddie.Visibility = Visibility.Visible;
            }
            SummonGoodie();
            SummonBaddies();
            counteBaddies = 10;
            goLeft = false;
            goRight = false;
            goDown = false;
            goUp = false;
            started = true;
            continueFromLost = 0; //  0 means the game will start and wont be in Won/Lost situation

        }


    }
}
