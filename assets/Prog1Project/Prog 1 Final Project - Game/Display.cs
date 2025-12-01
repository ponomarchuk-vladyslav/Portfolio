using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    internal class Display
    {
        //displays the map screen
        public void DrawMap(String[][] MapArray, Int32 Health, Int32 Weapon, Int32 Score, Int32 ShotgunAmmo, Int32 MGAmmo)
        {
            //vars setup
            Int32 Counter = 0;
            String[] Output1 = new String[25];
            String Output2 = "";

            //clear the screen
            Console.Clear();

            //join a jagged array of characters into a single array of strings
            Counter = 0;
            while (Counter < 25)
            {
                Output1[Counter] = String.Join("", MapArray[Counter]);
                Counter = Counter + 1;
            }
            //join an array of strings into a single string with line breaks
            Output2 = String.Join("\n", Output1);
            //output the resulting string
            Console.WriteLine(Output2);
            //diplay the health
            Console.WriteLine("Health: " + Health);
            //diplay the current weapon + ammo for it
            Console.Write("Current Weapon: ");
            switch (Weapon)
            {
                case 0:
                    Console.WriteLine("Pistol");
                    break;
                case 1:
                    Console.WriteLine("Shotgun: " + ShotgunAmmo + " Shells");
                    break;
                case 2:
                    Console.WriteLine("Machinegun: " + MGAmmo + " Bullets");
                    break;
            }
            //diplay the current score
            Console.WriteLine("Score: " + Score);
        }

        //note: the string.join method was used for performance. While that means no pretty colorfull maps, it allows me to refresh it 100 times a second with virtually no flicker
    }
}
