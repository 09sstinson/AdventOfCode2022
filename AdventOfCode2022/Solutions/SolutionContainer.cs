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
            InitializeDays();
        }

        private void InitializeDays()
        {
            for (var dayNumber = 1; dayNumber <= 25; dayNumber++)
            {
                var type = Type.GetType($"AdventOfCode2022.Solutions.Day{dayNumber}");

                if (type != null)
                {
                    var day = (IDay)Activator.CreateInstance(type);
                    Days.Add(dayNumber, day);
                }
            }
        }

        public string GetSolution(int dayNumber, DayPart part)
        {
            return part switch
            {
                DayPart.Part1 => Days.GetValueOrDefault(dayNumber).SolvePart1(InputHelper.GetDayInput(dayNumber)),
                DayPart.Part2 => Days.GetValueOrDefault(dayNumber).SolvePart2(InputHelper.GetDayInput(dayNumber)),
                _ => throw new NotImplementedException(),
            };
        }

        public void PrintAllSolutions()
        {
            foreach(var dayNumber in Days.Keys)
            {
                Console.WriteLine($"Day {dayNumber} - Part 1: {GetSolution(dayNumber, DayPart.Part1)}, Part 2: {GetSolution(dayNumber, DayPart.Part2)}");
            }
        }
    }

    public enum DayPart
    {
        Part1,
        Part2
    }
}
