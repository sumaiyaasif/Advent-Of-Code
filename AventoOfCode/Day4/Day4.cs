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

        public static void Part2()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day4/input.txt");
            string entireFile = File.ReadAllText(path);
            int validPassports = 0;
            string[] passports = entireFile.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string passport in passports)
            {
                string passportClean = passport.Replace("\n", " ");
                var result = passportClean.Split(" ").Select(x => x.Split(':')).ToDictionary(x => x[0], x => x[1]);
                if (passport.Contains("byr") && passport.Contains("iyr") && passport.Contains("eyr") && passport.Contains("hgt")
                && passport.Contains("hcl") && passport.Contains("ecl") && passport.Contains("pid"))
                {
                    if (Convert.ToInt32(result["byr"]) >= 1920 && Convert.ToInt32(result["byr"]) <= 2002)
                    {
                        if (Convert.ToInt32(result["iyr"]) >= 2010 && Convert.ToInt32(result["iyr"]) <= 2020)
                        {
                            if (Convert.ToInt32(result["eyr"]) >= 2020 && Convert.ToInt32(result["eyr"]) <= 2030)
                            {
                                string height = result["hgt"].ToString();
                                bool heightCm = height.Substring(height.Length - 2) == "cm";
                                bool heightIn = height.Substring(height.Length - 2) == "in";
                                if (heightCm || heightIn)
                                {
                                    int valueOfHeight = Convert.ToInt32(height.Substring(0, (height.Length - 2)));
                                    if (heightCm && (valueOfHeight >= 150 && valueOfHeight <= 193) ||
                                        heightIn && (valueOfHeight >= 59 && valueOfHeight <= 76))
                                    {
                                        var hairColor = result["hcl"].ToString().ToCharArray();
                                        if (hairColor.Length == 7 && hairColor[0] == '#')
                                        {
                                            char[] possiblities = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                                            var points = 0;
                                            for (int i = 1; i < hairColor.Length; i++)
                                            {
                                                if (possiblities.Contains(hairColor[i]))
                                                {
                                                    points++;
                                                }
                                            }
                                            // hair color requiremnet has been met
                                            if (points == 6)
                                            {
                                                string[] eyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                                if (eyeColors.Contains(result["ecl"].ToString()))
                                                {
                                                    if (result["pid"].ToString().ToCharArray().Length == 9)
                                                    {
                                                        validPassports++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            Console.WriteLine("valid passport: " + validPassports);
        }
    }
}
