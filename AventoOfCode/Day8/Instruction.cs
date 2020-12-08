using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace AventoOfCode.Day8
{
    public class Instruction
    { 
        public string instructionType;
        public int argument;
        public bool visited;
        public Instruction(string input)
        {
            instructionType = input.Split(" ")[0];
            argument = int.Parse(input.Split(" ")[1], NumberStyles.AllowLeadingSign);
            visited = false;
        }
    }
}