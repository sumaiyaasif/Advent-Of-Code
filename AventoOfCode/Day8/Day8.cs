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
            Console.WriteLine("end of program");
            var visitedInstructions = instructions.Where(element => (element.visited == true && element.instructionType != "acc"));

            foreach (var visited in visitedInstructions)
            {
                bool revisited = false;
                int cleanAccumulator = 0;
                List<Instruction> cleanInstructions = new List<Instruction>();
                foreach (var line in lines)
                {
                    cleanInstructions.Add(new Instruction(line));
                }
                for (int i = 0; i < cleanInstructions.Count;)
                {
                    if (cleanInstructions[i].visited == true)
                    {
                        Console.WriteLine("cleanAccumulator: " + cleanAccumulator);
                        revisited = true;
                        break;
                    }
                    if (visited.instructionType == cleanInstructions[i].instructionType &&
                    visited.argument == cleanInstructions[i].argument &&
                    visited.instructionType == "jmp")
                    {
                        cleanInstructions[i].instructionType = "nop";
                    }
                    else if (visited.instructionType == cleanInstructions[i].instructionType &&
                    visited.argument == cleanInstructions[i].argument &&
                    visited.instructionType == "nop")
                    {
                        cleanInstructions[i].instructionType = "jmp";
                    }
                    switch (cleanInstructions[i].instructionType)
                    {
                        case "acc":
                            cleanAccumulator += cleanInstructions[i].argument;
                            cleanInstructions[i].visited = true;
                            i++;
                            break;
                        case "jmp":
                            cleanInstructions[i].visited = true;
                            i = i + cleanInstructions[i].argument;
                            break;
                        case "nop":
                            cleanInstructions[i].visited = true;
                            i++;
                            break;

                    }
                }
                if (!revisited)
                {
                    Console.WriteLine("none have been revisited! cleanAccumulator: " + cleanAccumulator);
                    break;
                }
            }
            Console.WriteLine("Program completed. accumulator: " + accumulator);
        }

    }
}
