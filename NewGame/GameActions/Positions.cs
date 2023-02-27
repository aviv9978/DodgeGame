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
        private void SummonGoodie()
        {
            int bugsheight = rnd.Next(((int)(gamecanvas.ActualHeight - (bugs.ActualHeight * 2))));
            int bugswidth = rnd.Next(((int)(gamecanvas.ActualWidth - (bugs.ActualWidth * 2))));

            Canvas.SetTop(bugs, bugsheight);
            Canvas.SetLeft(bugs, bugswidth);
        } // Goodie random positin on start
        private void RandomPositionBaddies()
        {
            foreach (Rectangle baddie in baddiescontrol)
            {
                bool notContinueToNext = true;

                while (notContinueToNext == true)
                {
                    int baddieheight = rnd.Next(((int)(gamecanvas.ActualHeight - (baddie.ActualHeight*2))));
                    int baddiewidth = rnd.Next(((int)(gamecanvas.ActualWidth - (baddie.ActualWidth * 2))));
                    if (Math.Abs(Canvas.GetLeft(bugs) - baddiewidth) > 100 && Math.Abs(Canvas.GetTop(bugs) - baddieheight) > 100)
                    {
                        Canvas.SetTop(baddie, baddieheight);
                        Canvas.SetLeft(baddie, baddiewidth);
                        notContinueToNext = false;
                    }
                }
            }


        } // Baddies random position on start

        private bool nearBaddiesOrNot()
        {
            bool baddieNearBaddie = false;
            foreach (Rectangle baddie in baddiescontrol)
            {
                foreach (Rectangle otherbaddie in baddiescontrol)
                {
                    if (baddie != otherbaddie)
                    {
                        if (Math.Abs(Canvas.GetLeft(baddie) - Canvas.GetLeft(otherbaddie)) <= 50
                            && Math.Abs(Canvas.GetTop(baddie) - Canvas.GetTop(otherbaddie)) <= 50)
                            baddieNearBaddie = true;
                    }
                }
            }
            return baddieNearBaddie;
        } // Checking bool if baddie near baddie

        private void SummonBaddies()
        {
            RandomPositionBaddies();
            while (nearBaddiesOrNot() == true)
            {
                RandomPositionBaddies();
            }
        } //put baddies in random positions, If nearBaddie true - change baddies position over again
    }
}
