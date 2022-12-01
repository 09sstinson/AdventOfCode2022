using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    class Day1 : IDay
    {
        public string SolvePart1(IEnumerable<string> input)
        {
            var calories = GetCalories(input);

            return calories.Max().ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            var calories = GetCalories(input);

            return calories.OrderByDescending(x => x).Take(3).Sum().ToString();
        }

        private static List<int> GetCalories(IEnumerable<string> input)
        {
            var calories = new List<int>();
            var tempCalories = 0;

            foreach (var inputString in input)
            {
                if (inputString == null || inputString.Trim() == string.Empty)
                {
                    calories.Add(tempCalories);
                    tempCalories = 0;
                }
                else
                {
                    tempCalories += int.Parse(inputString);
                }
            }

            return calories;
        }
    }
}
