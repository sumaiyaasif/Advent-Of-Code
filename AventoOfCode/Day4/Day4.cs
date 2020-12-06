using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day4
{
    static class Day4
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day4/input.txt");
            string entireFile = File.ReadAllText(path);
            int validPassports = 0;
            string[] passports = entireFile.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(passports[0]);

            foreach (string passport in passports)
            {
                if (passport.Contains("byr") && passport.Contains("iyr") && passport.Contains("eyr") && passport.Contains("hgt")
                && passport.Contains("hcl") && passport.Contains("ecl") && passport.Contains("pid"))
                {
                    validPassports++;
                }
            }

            Console.WriteLine("Valid Passports: " + validPassports);
            
        }
    }
}
