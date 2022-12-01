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
            Days.Add(1, new Day1());
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
