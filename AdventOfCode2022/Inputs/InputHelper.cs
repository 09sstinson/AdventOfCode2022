using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    public static class InputHelper
    {
        public static IEnumerable<string> GetDayInput(int dayNumber) =>
            File.ReadLines($"Inputs/Day{dayNumber}/input.txt");
    }
}
