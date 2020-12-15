using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day13
{
    static class Day13
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day13/input.txt");
            string[] lines = File.ReadAllLines(path);
            int startingTime = Convert.ToInt32(lines[0]);
            string[] busIds = lines[1].Split(',');
            int busAnswer = 0;
            int nextBus = Int16.MaxValue;
            foreach(var id in busIds){
                if(id != "x"){
                    var busId = Convert.ToInt32(id);
                    var lastStop = startingTime / busId;
                    if(startingTime - (lastStop * busId) == 0){
                        busAnswer = busId;
                        break;
                    }
                    if(lastStop * busId + busId - startingTime < nextBus){
                        nextBus = lastStop * busId + busId - startingTime;
                        busAnswer = (busId - (startingTime - lastStop * busId)) * busId;
                    }

                }
            }
            Console.WriteLine("Bus Answer: " + busAnswer);
        }
    }
}
