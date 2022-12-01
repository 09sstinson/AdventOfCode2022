using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public interface IDay
    {
        public string SolvePart1(IEnumerable<string> input);
        public string SolvePart2(IEnumerable<string> input);
    }
}
