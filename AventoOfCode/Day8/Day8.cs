using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
namespace AventoOfCode.Day8
{
    static class Day8
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day8/input.txt");
            string[] lines = File.ReadAllLines(path);
            List<Instruction> instructions = new List<Instruction>();
            int accumulator = 0;
            foreach (var line in lines)
            {
                instructions.Add(new Instruction(line));
            }
            // iterate through list execute instruction as such
            for (int i = 0; i < instructions.Count;)
            {
                if (instructions[i].visited == true)
                {
                    Console.WriteLine("accumulator: " + accumulator);
                    break;
                }
                switch (instructions[i].instructionType)
                {
                    case "acc":
                        accumulator += instructions[i].argument;
                        instructions[i].visited = true;
                        i++;
                        break;
                    case "jmp":
                        instructions[i].visited = true;
                        i = i + instructions[i].argument;
                        break;
                    case "nop":
                        instructions[i].visited = true;
                        i++;
                        break;

                }
            }

        }

        public static void Part2()
        {

        }

    }
}
