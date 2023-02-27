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

namespace NewGame
{
    partial class GameWindow
    {
        int bugsspeed = 5;
        int bugsbuttonspeed = 20;
        int baddiesspeed = 10;
        bool goLeft, goRight, goUp, goDown, leftCtrlDown;
        Random rnd = new Random();

        private void bugsMovement(object sender, EventArgs e) // movement with keyboard
        {
            if (goLeft == true && Canvas.GetLeft(bugs) > 8)
            {
                Canvas.SetLeft(bugs, Canvas.GetLeft(bugs) - bugsspeed);
            }

            if (goRight == true && Canvas.GetLeft(bugs) + (bugs.Width + 8) < gamecanvas.ActualWidth)
            {
                Canvas.SetLeft(bugs, Canvas.GetLeft(bugs) + bugsspeed);
            }

            if (goUp == true && Canvas.GetTop(bugs) > 5)
            {
                Canvas.SetTop(bugs, Canvas.GetTop(bugs) - bugsspeed);
            }

            if (goDown == true && Canvas.GetTop(bugs) + (bugs.Height + 5) < gamecanvas.ActualHeight)
            {
                Canvas.SetTop(bugs, Canvas.GetTop(bugs) + bugsspeed);
            }
            Collisions();
            CheckIfGameWon();
        }
        private void baddiesChase(object sender, EventArgs e) // Baddies Movement
        {

            foreach (Rectangle baddie in baddiescontrol)
            {
                if (Canvas.GetTop(bugs) < Canvas.GetTop(baddie)) // baddie goes up to bugs
                    Canvas.SetTop(baddie, Canvas.GetTop(baddie) - baddiesspeed);
                else if (Canvas.GetTop(baddie) + (baddie.Height + 5) < gamecanvas.ActualHeight)
                    Canvas.SetTop(baddie, Canvas.GetTop(baddie) + baddiesspeed); // baddie goes down to bugs

                if (Canvas.GetLeft(bugs) < Canvas.GetLeft(baddie)) // baddie goes left to bugs
                    Canvas.SetLeft(baddie, Canvas.GetLeft(baddie) - baddiesspeed);
                else if (Canvas.GetLeft(baddie) + (baddie.Height + 8) < gamecanvas.ActualWidth)
                    Canvas.SetLeft(baddie, Canvas.GetLeft(baddie) + baddiesspeed); // baddie goes right to bugs
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Left)
            {
                goLeft = true;
            }

            if (e.Key == Key.Right)
            {
                goRight = true;
            }

            if (e.Key == Key.Down)
            {
                goDown = true;
            }

            if (e.Key == Key.Up)
            {
                goUp = true;
            }

            if (e.Key == Key.Space)
            {
                if (started == true) // only if started game (not in bugs timer)
                    SummonGoodie();
            }

            if (e.Key == Key.LeftCtrl) // ctrl + s to save (ctrl = true)
            {
                leftCtrlDown = true;
            }
            if (e.Key == Key.S) // ctrl + s to save
            {
                if (leftCtrlDown)
                    ClickToSave(sender, e);
            }

        } //define bool as true if pressing keyboard arrow and space and LeftCtrl+s to save

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                goLeft = false;

            if (e.Key == Key.Right)
                goRight = false;

            if (e.Key == Key.Down)
                goDown = false;

            if (e.Key == Key.Up)
                goUp = false;

            if (e.Key == Key.LeftCtrl) //  save from keyboard false (ctrl = false)
                leftCtrlDown = false;
        }//define bool as false if release keyboard arrow and LeftCtrl

        //Moving with buttons
        private void ClickW(object sender, RoutedEventArgs e) //Button W top
        {
                if (Canvas.GetTop(bugs) > 15 && started == true)
                {
                    Canvas.SetTop(bugs, Canvas.GetTop(bugs) - bugsbuttonspeed);
                }
        }
        private void ClickS(object sender, RoutedEventArgs e) //Button S bottom
        {
            if (Canvas.GetTop(bugs) + (bugs.Height + 20) < gamecanvas.ActualHeight && started == true)
            {
                Canvas.SetTop(bugs, Canvas.GetTop(bugs) + bugsbuttonspeed);

            }
        }

        private void ClickA(object sender, RoutedEventArgs e) // Button A left
        {
            if (Canvas.GetLeft(bugs) > 15 && started == true)
            {
                Canvas.SetLeft(bugs, Canvas.GetLeft(bugs) - bugsbuttonspeed);
            }
        }

        private void ClickD(object sender, RoutedEventArgs e) // Button D right
        {
            if (Canvas.GetLeft(bugs) + (bugs.Width + 20) < gamecanvas.ActualWidth && started == true)
            {
                Canvas.SetLeft(bugs, Canvas.GetLeft(bugs) + bugsbuttonspeed);
            }
        }

        private void ClickJump(object sender, RoutedEventArgs e) // Button Jump random postion
        {
            if (started == true)
            SummonGoodie();
        }


    }

}
