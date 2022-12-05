using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    public class Day5 : IDay
    {


        public string SolvePart1(IEnumerable<string> input)
        {
            var cratesRaw = input.Take(8).ToList();
            var movesRaw = input.Skip(10).ToList();

            var crates = PopulateCrates(cratesRaw);

            foreach(var move in movesRaw)
            {
                PerformMove(move, crates);
            }

            return new string(crates.Select(x => x.Last()).ToArray());
        }

        private static void PerformMove(string input, List<List<char>> crates)
        {
            var (numberOfCrates, sourceIndex, destinationIndex) = ParseMove(input);

            for (var i = 0; i < numberOfCrates; i++)
            {
                var crateToMove = crates[sourceIndex].Last();

                crates[sourceIndex].RemoveAt(crates[sourceIndex].Count - 1);

                crates[destinationIndex].Add(crateToMove);
            }
        }

        private static (int numberOfCrates, int sourceIndex, int destinationIndex) ParseMove(string input)
        {
            var moveNumbers = input
                .Split(
                new string[] { "move", "from", "to" },
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
                );

            return new(int.Parse(moveNumbers[0]), int.Parse(moveNumbers[1]) - 1, int.Parse(moveNumbers[2]) - 1);
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return "";
        }

        public List<List<char>> PopulateCrates(IEnumerable<string> input)
        {
            var crates = input.Select(x => x.Chunk(4).ToList()).ToList();

            var stacks = new List<List<char>>();    

            for(var i = 0; i < 9; i++)
            {
                stacks.Add(new List<char>());
            }
            
            for (var i = 0; i < crates.Count(); i++)
            {
                for (var j = 0; j < crates[i].Count; j++)
                {
                    if (crates[i][j][1] != ' ')
                    {
                        stacks[j] = stacks[j].Prepend(crates[i][j][1]).ToList();
                    }
                }
            }

            return stacks;
        }
    }
}
