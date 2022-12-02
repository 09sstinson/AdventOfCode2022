using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class Day2 : IDay
    {
        public string SolvePart1(IEnumerable<string> input)
        {
            var games = input.Select(x => ParseGame(x.ToCharArray()));

            return games.Select(x => x.GetPlayer2Score()).Sum().ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            var games = input.Select(x => ParseGameWithOutcomes(x.ToCharArray()));

            return games.Select(x => x.GetPlayer2Score()).Sum().ToString();
        }

        public static RockPaperScissorsGame ParseGame(char[] input)
        {
            return new RockPaperScissorsGame(ParseMove(input[0]), ParseMove(input[2]));
        }

        public static RockPaperScissorsGame ParseGameWithOutcomes(char[] input)
        {
            return new RockPaperScissorsGame(ParseMove(input[0]), ParseOutcome(input[2]));
        }

        public static Outcome ParseOutcome(char c)
        {
            return c switch
            {
                'X' => Outcome.Player1Win,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Player2Win,
                _ => throw new NotImplementedException()
            };
        }

        public static Move ParseMove(char c)
        {
            return c switch
            {
                'A' or 'X' => Move.Rock,
                'B' or 'Y' => Move.Paper,
                'C' or 'Z' => Move.Scissors,
                _ => throw new NotImplementedException()
            };
        }
    }
}
