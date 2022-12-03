using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    public class Day3 : IDay
    {
        public static string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string SolvePart1(IEnumerable<string> input)
        {
            return input.Select(GetPriorityScore).Sum().ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return input
                .Chunk(3)
                .Select(GetBackPackPriority)
                .Sum()
                .ToString();
        }

        public static int GetPriorityScore(string input)
        {
            var compartments = GetCompartments(input);

            var sharedCharacter = FindSharedCharacter(compartments);

            return Alphabet.IndexOf(sharedCharacter) + 1;
        }

        public static int GetBackPackPriority(string[] input)
        {
            var sharedCharacter = FindSharedCharacter(input);

            return Alphabet.IndexOf(sharedCharacter) + 1;
        }

        private static string[] GetCompartments(string input)
        {
            var midpoint = input.Length / 2;

            return new string[] { input.Substring(0, midpoint), input.Substring(midpoint) };
        }

        private static char FindSharedCharacter(string[] stringsToCheck)
        {
            return Alphabet
                .Where(c => stringsToCheck.All(x => x.Contains(c)))
                .Single();
        }
    }
}
