using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public interface IDay<TInput>
    {
        public string SolvePart1(TInput input);
        public string SolvePart2(TInput input);
    }
}
