using System;
using System.IO;
using System.Collections.Generic;

namespace Kata2 {
    class Part1 {
        public static void Main() {
            string line;
            StreamReader file = new StreamReader(@"weather.dat");

            List<Day> days = new List<Day>();
	        while ((line = file.ReadLine()) != null) {
                string[] columns = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (columns.Length < 14 || "Dy".Equals(columns[0])) {
                    continue;
                }
 
                int number = int.Parse(columns[0]);
                int max = Convert(columns[1]);
                int min = Convert(columns[2]);
                days.Add(new Day(number, max, min));
            }

            days.Sort();
            Console.WriteLine(days[0]);

            file.Close();
        }

        public static int Convert(string val) {
            if (val.EndsWith("*")) {
                val = val.Substring(0, 2);
            }
            return int.Parse(val);
        }
    
        private class Day : IComparable<Day> {
            private int number;
            private int spread;

            public Day (int number, int max, int min) {
                this.number = number;
                spread = max - min;
            }

            public override string ToString() {
                return number.ToString();
            }

            public int CompareTo(Day other) {
                return spread.CompareTo(other.spread);
            }
        }
        
    }        
}
