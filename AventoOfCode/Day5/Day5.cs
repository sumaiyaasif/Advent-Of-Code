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
                int row = 0;
                int col = 0;

                char[] boardingPassRow = line.Substring(0, 7).ToArray();
                char[] boardingPassCol = line.Substring(7, 3).ToArray();
                row = Position(boardingPassRow, 0, 127);
                col = Position(boardingPassCol, 0, 7);
                var currentSeat = row * 8 + col;
                if (currentSeat > highestSeat)
                {
                    highestSeat = currentSeat;
                }

            }
            Console.WriteLine("Seat: " + highestSeat);

        }

        private static int Position(char[] boardingPass, int minimum, int maximum)
        {
            var range = maximum + 1;
            for (int i = 0; i < boardingPass.Length; i++)
            {
                if (boardingPass[i] == 'F' || boardingPass[i] == 'L')
                {
                    maximum = maximum - range / 2;
                    if (i == boardingPass.Length -1) { return maximum; }
                }
                if (boardingPass[i] == 'B' || boardingPass[i] == 'R')
                {
                    minimum = minimum + range / 2;
                    if (i == boardingPass.Length -1) { return minimum; }
                }
                range = maximum - minimum + 1;
            }
            return 0;
        }
        public static void Part2()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day5/input.txt");
            string[] lines = File.ReadAllLines(path);

            List<int> seatIds = new List<int>();
            foreach (var line in lines)
            {
                int row = 0;
                int col = 0;

                char[] boardingPassRow = line.Substring(0, 7).ToArray();
                char[] boardingPassCol = line.Substring(7, 3).ToArray();
                row = Position(boardingPassRow, 0, 127);
                col = Position(boardingPassCol, 0, 7);
                seatIds.Add(row * 8 + col);
            }
            seatIds.Sort();
            for (int i = 0; i < seatIds.Count - 1; i++)
            {
                if ((seatIds[i] + 2) == seatIds[i + 1])
                {
                    Console.WriteLine(seatIds[i] + 1);
                }
            }

        }

    }
}
