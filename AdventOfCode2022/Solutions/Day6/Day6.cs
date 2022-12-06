using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2022.Solutions
{
    public class Day6 : IDay
    {
        public string SolvePart1(IEnumerable<string> input)
        {
            return GetPositionOfDistinctValues(input.First(), 4).ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            return GetPositionOfDistinctValues(input.First(), 14).ToString();
        }

        private int GetPositionOfDistinctValues(string input, int numberOfDistinctValues)
        {
            var buffer = new FixedSizeQueue<char>(numberOfDistinctValues);

            for (var i = 0; i < input.Length; i++)
            {
                buffer.Enqueue(input[i]);

                if (buffer.IsDistinct())
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
