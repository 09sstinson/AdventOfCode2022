using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    public class Day3 : IDay
    {
        public static char[] Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public string SolvePart1(IEnumerable<string> input)
        {
            return input.Select(x => GetPriorityScore(x)).Sum().ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return input
                .Select((x, index) => new { Index = index, Value = x })
                .GroupBy(x => x.Index / 3)
                .Select(x => GetBackPackPriority(x.Select(v => v.Value).ToArray()))
                .Sum()
                .ToString();
        }

        public static int GetPriorityScore(string input)
        {
            var compartments = GetCompartments(input);

            var sharedCharacter = FindSharedCharacter(compartments);

            return Array.IndexOf(Alphabet, sharedCharacter) + 1;
        }

        public static int GetBackPackPriority(string[] input)
        {
            var sharedCharacter = FindSharedCharacter(input);

            return Array.IndexOf(Alphabet, sharedCharacter) + 1;
        }

        private static string[] GetCompartments(string input)
        {
            var midpoint = input.Length / 2;

            return new string[] { input.Substring(0, midpoint), input.Substring(midpoint) };
        }

        private static char FindSharedCharacter(string[] strings)
        {
            foreach(var character in Alphabet)
            {
                var containedInAll = true;

                foreach (var stringToCheck in strings)
                {
                    if (!stringToCheck.Contains(character, StringComparison.Ordinal))
                    {
                        containedInAll = false;
                    }
                }

                if (containedInAll)
                {
                    return character;
                }
            }

            throw new Exception("Couldn't find shared character");
        }
    }
}
