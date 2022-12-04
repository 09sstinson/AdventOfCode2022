using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2022.Solutions
{
    public class Day4 : IDay
    {
        private static readonly Regex _regex = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");

        public string SolvePart1(IEnumerable<string> input)
        {
            return input
                .Select(x => _regex.Match(x))
                .Select(x => RangeHelpers.IsOneRangeFullyContained(x.Groups[1].Value, x.Groups[2].Value, x.Groups[3].Value, x.Groups[4].Value))
                .Count(x => x).ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return input
                .Select(x => _regex.Match(x))
                .Select(x => RangeHelpers.HasOverlap(x.Groups[1].Value, x.Groups[2].Value, x.Groups[3].Value, x.Groups[4].Value))
                .Count(x => x).ToString();
        }
    }
}
