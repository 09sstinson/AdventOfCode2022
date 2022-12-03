using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public static class StringHelpers
    {
        public static IEnumerable<char> FindSharedCharacters(string[] stringsToCheck)
        {
            IEnumerable<char> intersection = stringsToCheck[0];

            for (var i = 1; i < stringsToCheck.Length; i++)
            {
                intersection = intersection.Intersect(stringsToCheck[i]);
            }

            return intersection;
        }
    }
}
