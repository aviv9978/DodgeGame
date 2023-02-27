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
using System.IO;
using System.Diagnostics;
using Path = System.IO.Path;

namespace NewGame
{
    partial class GameWindow
    {
        private bool easyMode = false, normalMode = false, hardMode = false, started = false;
        //Difficults Levels
        private void DiffEasy(object sender, RoutedEventArgs e)
        {
            if (started == false)
            {
                easyMode = true;
                normalMode = false;
                hardMode = false;

                baddiesGameTimer.Interval = TimeSpan.FromMilliseconds(600);
                easybtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF040422"); // turn into darksome navy
                easybtn.Background = new SolidColorBrush(Colors.DarkCyan);

                normalbtn.Background = new SolidColorBrush(Colors.Transparent);
                normalbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint

                hardbtn.Background = new SolidColorBrush(Colors.Transparent);
                hardbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint
            }
        } //Easy
        private void DiffNormal(object sender, RoutedEventArgs e)
        {
            if (started == false)
            {
                normalMode = true;
                easyMode = false;
                hardMode = false;

                baddiesGameTimer.Interval = TimeSpan.FromMilliseconds(350);
                normalbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF040422"); // turn into darksome navy
                normalbtn.Background = new SolidColorBrush(Colors.DarkCyan);

                easybtn.Background = new SolidColorBrush(Colors.Transparent);
                easybtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint

                hardbtn.Background = new SolidColorBrush(Colors.Transparent);
                hardbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint
            }

        } //Normal
        private void DiffHard(object sender, RoutedEventArgs e)
        {
            if (started == false)
            {
                hardMode = true;
                easyMode = false;
                normalMode = false;

                baddiesGameTimer.Interval = TimeSpan.FromMilliseconds(100);
                hardbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF040422"); // turn into darksome navy
                hardbtn.Background = new SolidColorBrush(Colors.DarkCyan);

                easybtn.Background = new SolidColorBrush(Colors.Transparent);
                easybtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint

                normalbtn.Background = new SolidColorBrush(Colors.Transparent);
                normalbtn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4BEBBA"); // turn into original mint
            }
        } //Hard






    }
}
