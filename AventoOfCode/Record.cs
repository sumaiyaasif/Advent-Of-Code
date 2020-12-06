using System;
namespace AventoOfCode
{
    public class Record
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char SignificantLetter { get; set; }
        public string Password { get; set; }

        public Record(int min, int max, char significantLetter, string password)
        {
            Min = min;
            Max = max;
            SignificantLetter = significantLetter;
            Password = password;
        }

    }
}
