using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day6
{
    static class Day6
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day6/input.txt");
            string entireFile = File.ReadAllText(path);
            string[] groups = entireFile.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            int allUniqueAnswers = 0;
            foreach( var group in groups) {
                string groupClean = group.Replace("\n", "");
                char[] answer = groupClean.Distinct().ToArray();
                allUniqueAnswers += answer.Length;
            }
            Console.WriteLine("total unique answers: " + allUniqueAnswers);

        }

        public static void Part2()
        {


        }

    }
}
