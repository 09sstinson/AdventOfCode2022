using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public abstract class Day<TInput>
    {
        public abstract string SolvePart1(TInput input);
        public abstract string SolvePart2(TInput input);
    }
}
