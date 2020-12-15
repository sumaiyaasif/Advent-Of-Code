using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day15
{
    static class Day15
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day15/input.txt");
            string[] lines = File.ReadAllLines(path);
            string[] startingNums = lines[0].Split(',');
            Dictionary<int, List<int>> calledNums = new Dictionary<int, List<int>>();
            int x = 0;
            int lastNum = 0;
            int newNum = 0;
            while (x < startingNums.Length)
            {
                calledNums.Add(Convert.ToInt32(startingNums[x]), new List<int>(){x});
                lastNum = Convert.ToInt32(startingNums[x]);
                x++;
            }
            if (calledNums[lastNum].Count == 1)
            {
                if (calledNums.ContainsKey(0))
                {
                    calledNums[0].Add(startingNums.Length);
                    newNum = calledNums[0].Max() - calledNums[0].Min();
                }else {
                    calledNums.Add(0, new List<int>(){startingNums.Length});
                    newNum = 0;
                }
            }
            for (int index = startingNums.Length + 1; index <= 2018; index++)
            {
                if (calledNums.ContainsKey(newNum))
                {
                    if (calledNums[newNum].Count >= 2)
                    {
                        calledNums[newNum].Remove(calledNums[newNum].Min());
                        calledNums[newNum].Add(index);
                        newNum = calledNums[newNum].Max() - calledNums[newNum].Min();
                    }
                    else
                    {
                        calledNums[newNum].Add(index);
                        newNum = calledNums[newNum].Max() - calledNums[newNum].Min();
                    }
                }
                else{
                    calledNums.Add(newNum, new List<int>(){index});
                    newNum = 0;
                }
            }
            Console.WriteLine("Answer to this alien game: " + newNum);

        }
    }
}
