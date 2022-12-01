using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class SolutionContainer
    {
        private Dictionary<int, IDay> Days = new Dictionary<int, IDay>();

        public SolutionContainer()
        {
            for(var dayNumber = 1; dayNumber <= 25; dayNumber++)
            {
                var type = Type.GetType($"AdventOfCode2022.Solutions.Day{dayNumber}");

                if (type != null)
                {
                    var day = (IDay)Activator.CreateInstance(type);
                    Days.Add(1, day);
                }
            }
        }

        public string GetSolution(int dayNumber, DayPart part)
        {
            return part switch
            {
                DayPart.Part1 => Days.GetValueOrDefault(dayNumber).SolvePart1(Inputs.GetDayInput(dayNumber)),
                DayPart.Part2 => Days.GetValueOrDefault(dayNumber).SolvePart2(Inputs.GetDayInput(dayNumber)),
                _ => throw new NotImplementedException(),
            };
        }
    }

    public enum DayPart
    {
        Part1,
        Part2
    }
}
