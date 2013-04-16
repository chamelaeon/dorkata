using System;
using System.IO;
using System.Collections.Generic;

namespace Kata2 {

    class Final {
        public static void Main() {
            Part1.DoPart();
            Part2.DoPart();
        }
    }

    class Part1 {
        public static void DoPart() {
            List<string> ignoreTokens = new List<string>();
            ignoreTokens.Add("Dy");
            Console.WriteLine(Part3.FindMinimumSpreadPoint(@"weather.dat", 0, 1, 2, 14, ignoreTokens));
        }
    }

    class Part2 {
        public static void DoPart() {
            Console.WriteLine(Part3.FindMinimumSpreadPoint(@"football.dat", 1, 6, 8, 10, new List<string>()));
        }
    }
     
    class Part3 {
        public static DataPoint FindMinimumSpreadPoint(string filename, int nameIndex, int value1Index, int value2Index, int minColumns, List<string> ignoreTokens) {
            StreamReader file = new StreamReader(filename);
            try {
                string line;
                List<DataPoint> datapoints = new List<DataPoint>();
	            while ((line = file.ReadLine()) != null) {
                    string[] columns = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (columns.Length < minColumns || ignoreTokens.Contains(columns[0])) {
                        continue;
                    }
                    
                    string name = columns[nameIndex];
                    int value1 = Convert(columns[value1Index]);
                    int value2 = Convert(columns[value2Index]);
                    DataPoint datapoint = new DataPoint(name, value1, value2);
                    datapoints.Add(datapoint);
                }

                datapoints.Sort();
                return datapoints[0];
            } finally {
                file.Close();
            }
        }

        public static int Convert(string val) {
            if (val.EndsWith("*")) {
                val = val.Substring(0, 2);
            }
            return int.Parse(val);
        }
    }
    
    class DataPoint : IComparable<DataPoint> {
        private string name;
        private int spread;
     
        public DataPoint(string name, int value1, int value2) {
            this.name = name;
            this.spread = Math.Abs(value1 - value2);
        }

        public override string ToString() {
            return name + " " + spread;
        }

        public int CompareTo(DataPoint other) {
            return spread.CompareTo(other.spread);
        }
    }
}
