using System;
using System.IO;
using System.Collections.Generic;

namespace Kata2 {
    class Part2 {
        public static void Main() {
            string line;
            StreamReader file = new StreamReader(@"football.dat");

            List<Game> games = new List<Game>();
	        while ((line = file.ReadLine()) != null) {
                string[] columns = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (columns.Length < 10) {
                    continue;
                }

                int goalsFor = int.Parse(columns[6]);
                int goalsAgainst = int.Parse(columns[8]);
                Game game = new Game(columns[1], goalsFor, goalsAgainst);
                Console.WriteLine(game);
                games.Add(game);
            }

            games.Sort();
            Console.WriteLine(games[0]);
            file.Close();
        }
    }

    class Game : IComparable<Game>{
        private string name;
        private int spread;
     
        public Game(string name, int goalsFor, int goalsAgainst) {
            this.name = name;
            this.spread = Math.Abs(goalsFor - goalsAgainst);
        }

        public override string ToString() {
            return name + " " + spread;
        }

        public int CompareTo(Game other) {
            return spread.CompareTo(other.spread);
        }
    }
}
