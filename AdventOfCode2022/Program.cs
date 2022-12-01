using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    class Program
    {
        const string InputFileLocation = "C:\\Users\\Home\\Documents\\Aoc2022\\Day1\\input.txt";
        static void Main(string[] args)
        {
            var inputStrings = File.ReadAllLines(InputFileLocation);

            var calories = new List<int>();
            var tempCalories = 0;
            foreach (var input in inputStrings)
            {
                if(input == null || input.Trim() == string.Empty)
                {
                    calories.Add(tempCalories);
                    tempCalories = 0;
                } 
                else
                {
                    tempCalories += int.Parse(input);
                }
            }

            Console.WriteLine(calories.OrderByDescending(x => x).Take(3).Sum());
        }
    }
}
