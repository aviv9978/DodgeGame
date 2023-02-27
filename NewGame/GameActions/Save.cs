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
    partial class GameWindow // ctrl+s to save in Movement class
    {
        private void ClickToSave(object sender, RoutedEventArgs e) //Click To Save Game
        {
            if (startbtn.Visibility != Visibility.Visible) // can save only after pressing start first game
            {
            string defaultFolder = System.AppDomain.CurrentDomain.BaseDirectory; // debug folder

            if (!File.Exists(loadFilePath))
            {
                string newpath = Path.GetFullPath(Path.Combine(defaultFolder, @"..\..\Saves")); // to Saves folder
                var numberOfSaves = Directory.GetFiles(newpath, "*.save*").Length; // how many saves are
                string fileName = @"DodgeGame" + (numberOfSaves) + " .save"; // name of save file
                this.loadFilePath = Path.Combine(newpath, fileName); // combine between folder to save name
            }

            using (StreamWriter sw = File.CreateText(this.loadFilePath))
            {
                sw.WriteLine($"good: left: #{Canvas.GetLeft(bugs)}#, top: #{Canvas.GetTop(bugs)}#");
                for (int i = 0; i < baddiescontrol.Length; i++)
                {
                    if (baddiescontrol[i].Visibility == Visibility.Visible)
                        sw.WriteLine($"baddie{i}: left: #{Canvas.GetLeft(baddiescontrol[i])}#, top: #{Canvas.GetTop(baddiescontrol[i])}#, visbaility: #{0}#");
                    else // visability collapsed
                        sw.WriteLine($"baddie{i}: left: #{Canvas.GetLeft(baddiescontrol[i])}#, top: #{Canvas.GetTop(baddiescontrol[i])}#visbaility: #{-1}#");
                }
                sw.WriteLine($"Wins: #{countWin}# Loses: #{countLose}#");
                sw.WriteLine($"Baddies Counter: #{counteBaddies}# ContinueFromLose: #{continueFromLost}#");
            }
            }

        }

        public void ReadDataFromSave(string filePath) //Load the details from save into game
        {
            int c = 0; //read data from C line
            string path = filePath;
            if (File.Exists(path))
            {
                string[] Lines = File.ReadAllLines(path);
                string[] goodieParts = Lines[c].Split('#');
                c++;

                Canvas.SetLeft(bugs, int.Parse(goodieParts[1]));
                Canvas.SetTop(bugs, int.Parse(goodieParts[3]));

                for (int i = 0; i < baddiescontrol.Length; i++)
                {
                    string[] baddieParts = Lines[c].Split('#');
                    Canvas.SetLeft(baddiescontrol[i], int.Parse(baddieParts[1]));
                    Canvas.SetTop(baddiescontrol[i], int.Parse(baddieParts[3]));
                    if (int.Parse(baddieParts[5]) == -1)
                        baddiescontrol[i].Visibility = Visibility.Collapsed;
                    c++;
                }
                string[] winsOrloses = Lines[c].Split('#');
                countWin = int.Parse(winsOrloses[1]);
                countLose = int.Parse(winsOrloses[3]);
                c++;
                string[] countBaddiesAndContinueFromLost = Lines[c].Split('#');
                counteBaddies = int.Parse(countBaddiesAndContinueFromLost[1]);
                continueFromLost = int.Parse(countBaddiesAndContinueFromLost[3]);
                c++;
            }
        }
    }
}
