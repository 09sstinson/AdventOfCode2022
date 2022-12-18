using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    internal class Day8 : IDay
    {
        public string SolvePart1(IEnumerable<string> input)
        {
            var trees = input.Select(x => x.ToCharArray()).ToArray();

            var sum = 0;
            
            for(var i = 0; i < trees.Length; i++ )
            {
                var row = GetRow(trees, i);
                for (var j = 0; j < trees[i].Length; j++)
                {
                    if (IsVisible(i, GetColumn(trees, j)) || IsVisible(j, row))
                    {
                        sum++;
                    }
                }
            }

            return sum.ToString();
        }


        public string SolvePart2(IEnumerable<string> input)
        {
            var trees = input.Select(x => x.ToCharArray()).ToArray();

            var visibleTreesCount = new List<int>();

            for (var i = 0; i < trees.Length; i++)
            {
                var row = GetRow(trees, i);

                for (var j = 0; j < trees[i].Length; j++)
                {
                    visibleTreesCount.Add(GetScenicScore(i, j, row, GetColumn(trees, j)));
                }
            }

            return visibleTreesCount.Max().ToString();
        }

        private int[] GetRow(char[][] trees, int i)
        {
            return trees[i].Select(x => int.Parse(x.ToString())).ToArray();
        }

        private int[] GetColumn(char[][] trees, int j)
        {
            return Enumerable.Range(0, trees[0].Length).Select(x => int.Parse(trees[x][j].ToString())).ToArray();
        }

        private bool IsVisible(int index, int[] row)
        {
            if(index == 0 || index == row.Length - 1)
            {
                return true;
            }

            var value = row[index];

            return row.Take(index).Max() < value || row.Skip(index + 1).Max() < value;
        }

        public int GetScenicScore(int rowIndex, int columnIndex, int[] row, int[] column)
        {
            var rowCounts = GetVisibleTreesCount(columnIndex, row);
            var columnCounts = GetVisibleTreesCount(rowIndex, column);
            return rowCounts.left * rowCounts.right * columnCounts.left * columnCounts.right);
        }

        private (int left, int right) GetVisibleTreesCount(int index, int[] row)
        {
            var indexInReversedRow = row.Length - 1 - index;

            return (GetTreesVisibleToTheLeft(index, row),
                GetTreesVisibleToTheLeft(indexInReversedRow, row.Reverse().ToArray()));
        }

        private int GetTreesVisibleToTheLeft(int index, int[] row)
        {
            var count = 0;
            for (var i = index; i > 0; i--)
            {
                count++;

                if (row[i - 1] >= row[index])
                {
                    break;
                }
            }
            return count;
        }
    }
}
