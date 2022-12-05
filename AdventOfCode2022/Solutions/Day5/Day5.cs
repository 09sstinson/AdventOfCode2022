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
            return PerformMoves(input, moveAllAtOnce: false);
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return PerformMoves(input, moveAllAtOnce: true);
        }

        private string PerformMoves(IEnumerable<string> input, bool moveAllAtOnce)
        {
            var (crates, moves) = ParseInput(input);

            foreach (var move in moves)
            {
                PerformMove(move, crates, moveAllAtOnce);
            }

            return new string(crates.Select(x => x.First()).ToArray());
        }

        private static (List<List<char>> crates, IEnumerable<Move> moves) ParseInput(IEnumerable<string> input)
        {
            return (GetCrates(input.Take(8).ToList()), input.Skip(10).Select(ParseMove));
        }

        private static void PerformMove(Move move, List<List<char>> crates, bool moveAllAtOnce)
        {
            var cratesMoved = 0;
            var moveCapacity = moveAllAtOnce ? move.NumberOfCrates : 1;
            while (cratesMoved < move.NumberOfCrates)
            {
                var cratesToMove = crates[move.SourceIndex].GetRange(0, moveCapacity);

                crates[move.SourceIndex].RemoveRange(0, moveCapacity);

                crates[move.DestinationIndex].InsertRange(0, cratesToMove);
                cratesMoved += moveCapacity;
            }
        }

        private static Move ParseMove(string input)
        {
            var moveNumbers = input.Split(
                new string[] { "move", "from", "to" },
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
                );

            return new Move() { 
                NumberOfCrates = int.Parse(moveNumbers[0]),
                SourceIndex = int.Parse(moveNumbers[1]) - 1, 
                DestinationIndex = int.Parse(moveNumbers[2]) - 1
            };
        }

        public static List<List<char>> GetCrates(IEnumerable<string> input)
        {
            // TODO improve this
            var crates = input.Select(x => x.Chunk(4).ToList()).ToList();

            var stacks = new List<List<char>>();    

            for(var i = 0; i < crates[0].Count; i++)
            {
                stacks.Add(new List<char>());
            }

            for (var i = 0; i < crates.Count(); i++)
            {
                for (var j = 0; j < crates[i].Count; j++)
                {
                    if (crates[i][j][1] != ' ')
                    {
                        stacks[j].Add(crates[i][j][1]);
                    }
                }
            }

            return stacks;
        }

        public record Move
        {
            public int NumberOfCrates { get; init; }
            public int SourceIndex { get; init; }
            public int DestinationIndex { get; init; }
        }
    }
}
