using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day5
{
    static class Day5
    {
        public static void Part1()
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day5/input.txt");
            string[] lines = File.ReadAllLines(path);

            int highestSeat = 0;
            foreach (var line in lines)
            {
                char[] boardingPass = line.ToString().ToCharArray();
                int minimum = 0;
                int maximum = 127;
                int range = 128;
                int row = 0;
                int col = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (boardingPass[i] == 'F')
                    {
                        maximum = maximum - range / 2;
                        range = maximum - minimum;
                        if (i == 6) { row = maximum; }
                    }
                    if (boardingPass[i] == 'B')
                    {
                        minimum = minimum + range / 2;
                        range = maximum - minimum;
                        if (i == 6) { row = minimum; }
                    }
                }
                minimum = 0;
                maximum = 7;
                range = 8;
                for (int i = 7; i < 10; i++) {
                    if (boardingPass[i] == 'L')
                    {
                        maximum = maximum - range / 2;
                        range = maximum - minimum;
                        if (i == 9) { col = maximum; }
                    }
                    if (boardingPass[i] == 'R')
                    {
                        minimum = minimum + range / 2;
                        range = maximum - minimum;
                        if (i == 9) { col = minimum; }
                    }
                }
                var currentSeat = row * 8 + col;
                if ( currentSeat > highestSeat) {
                    highestSeat = currentSeat;
                }
            }
            Console.WriteLine("Highest Seat: " + highestSeat);

        }



    }
}
