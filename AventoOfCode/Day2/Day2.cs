using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AventoOfCode.Day2
{
    static class Day2
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day2/input.txt");
            string[] lines = File.ReadAllLines(path);
            int validPasswords = 0;
            List<Record> records = new List<Record>();
            foreach (string line in lines)
            {
                string[] lineArray = line.Split(null);
                int minimum = Int32.Parse(lineArray[0].Split('-')[0]);
                int maximum = Int32.Parse(lineArray[0].Split('-')[1]);
                char significantChar = Convert.ToChar(lineArray[1].Substring(0, 1));
                string password = lineArray[2];
                records.Add(new Record(minimum, maximum, significantChar, password));

            }

            foreach (Record record in records)
            {
                var count = record.Password.Count(x => x == record.SignificantLetter);
                if (count >= record.Min && count <= record.Max)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine("valid: " + validPasswords);
        }

        public static void Part2()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day2/input.txt");
            string[] lines = File.ReadAllLines(path);
            int validPasswords = 0;
            List<Record> records = new List<Record>();
            foreach (string line in lines)
            {
                string[] lineArray = line.Split(null);
                int minimum = Int32.Parse(lineArray[0].Split('-')[0]);
                int maximum = Int32.Parse(lineArray[0].Split('-')[1]);
                char significantChar = Convert.ToChar(lineArray[1].Substring(0, 1));
                string password = lineArray[2];
                records.Add(new Record(minimum, maximum, significantChar, password));

            }

            foreach (Record record in records)
            {
                var passwordCharArray = record.Password.ToCharArray();
                if (record.Max - 1 < record.Password.Length)
                {
                    if ((passwordCharArray[record.Min - 1] == record.SignificantLetter) && (passwordCharArray[record.Max - 1] != record.SignificantLetter))
                    {
                        validPasswords++;
                    }
                    else if ((passwordCharArray[record.Min - 1] != record.SignificantLetter) && (passwordCharArray[record.Max - 1] == record.SignificantLetter))
                    {
                        validPasswords++;
                    }
                }
                else if (passwordCharArray[record.Min - 1] == record.SignificantLetter)
                {
                    validPasswords++;
                }

            }

            Console.WriteLine("validHEHE: " + validPasswords);
        }

    }



}
