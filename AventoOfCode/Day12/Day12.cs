using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day12
{
    static class Day12
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day12/input.txt");
            string[] lines = File.ReadAllLines(path);
            char[] directionsStore = {'N', 'E', 'S', 'W'};
            int x = 0;
            int y = 0;
            char currDirection = 'E';
            foreach(var line in lines){
                char instruction = line.Substring(0,1).ToCharArray()[0];
                int amount = Convert.ToInt32(line.Substring(1));
                if(instruction == 'N'){
                    y += amount;
                }
                else if(instruction == 'S'){
                    y -= amount;
                }
                else if(instruction == 'E'){
                    x += amount;
                }
                else if(instruction == 'W'){
                    x -= amount;
                }
                else if(instruction == 'F' && currDirection == 'E'){
                    x += amount;
                }
                else if(instruction == 'F' && currDirection == 'W'){
                    x -= amount;
                }
                else if(instruction == 'F' && currDirection == 'N'){
                    y += amount;
                }
                else if(instruction == 'F' && currDirection == 'S'){
                    y -= amount;
                }
                else if(instruction == 'L'){
                    var shifts = amount / 90;
                    var currIndex = Array.IndexOf(directionsStore, currDirection);
                    var result = currIndex - shifts;
                    while( result < 0){
                        result += 4;
                    }
                    currDirection = directionsStore[result];
                }
                else if(instruction == 'R'){
                    var shifts = amount / 90;
                    var currIndex = Array.IndexOf(directionsStore, currDirection);
                    var result = currIndex + shifts;
                    while( result >= 4){
                        result -= 4;
                    }
                    currDirection = directionsStore[result];
                }
            }
            Console.WriteLine("X: " + x + " Y: " + y);
            Console.WriteLine("Sum of absolute values:  {0}",  Math.Abs(x) +  Math.Abs(y) );
        }
    }
}
