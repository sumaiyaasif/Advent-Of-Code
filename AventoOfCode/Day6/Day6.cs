using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
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
            foreach (var group in groups)
            {
                string groupClean = group.Replace("\n", "");
                char[] answer = groupClean.Distinct().ToArray();
                allUniqueAnswers += answer.Length;
            }
            Console.WriteLine("total unique answers: " + allUniqueAnswers);

        }

        public static void Part2()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day6/input.txt");
            string entireFile = File.ReadAllText(path);
            string[] groups = entireFile.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            int groupAnswer = 0;
            foreach (var group in groups)
            {
                string[] groupMembers = group.Split('\n');
                Dictionary<char, int> answerSet = new Dictionary<char, int>();
                // add all answers from first group to hash set
                foreach (char answer in groupMembers[0]) {
                    answerSet.Add(answer, 0);
                }
                // iterate through each member in group
                foreach (string member in groupMembers) {
                    char[] memberAnswerSet = member.ToCharArray();
                    // iterate through the answerSet and check if the current answer set co
                    foreach( var answer in memberAnswerSet) {
                        if (answerSet.Keys.Contains(answer)){
                            answerSet[answer] = answerSet[answer] + 1;
                        }
                    }
                }
                // go through the dict and find values that equal the amount of groupmembers
                foreach(var element in answerSet) {
                    if (element.Value == groupMembers.Length){
                        groupAnswer++;
                    }
                }
            }
            Console.WriteLine("total unique answers: " + groupAnswer);

        }

    }
}
