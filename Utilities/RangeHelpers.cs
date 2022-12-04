using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class RangeHelpers
    {
        public static bool HasOverlap(string xstart, string xend, string ystart, string yend)
        {
            return HasOverlap(int.Parse(xstart), int.Parse(xend), int.Parse(ystart), int.Parse(yend));
        }

        public static bool HasOverlap(int xstart, int xend, int ystart, int yend)
        {
            return xstart <= yend && ystart <= xend;
        }

        public static bool IsOneRangeFullyContained(string xstart, string xend, string ystart, string yend)
        {
            return IsOneRangeFullyContained(int.Parse(xstart), int.Parse(xend), int.Parse(ystart), int.Parse(yend));
        }

        public static bool IsOneRangeFullyContained(int xstart, int xend, int ystart, int yend)
        {
            var minStart = Math.Min(xstart, ystart);
            var maxStart = Math.Max(xend, yend);
            return (xstart == minStart && xend == maxStart) || (ystart == minStart && yend == maxStart);
        }
    }
}
