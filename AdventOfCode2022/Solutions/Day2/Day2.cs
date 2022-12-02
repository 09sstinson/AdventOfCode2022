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
            var games = input.Select(x => ParseGame(x));

            return games.Select(x => x.GetPlayer2Score()).Sum().ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            var games = input.Select(x => ParseGameWithOutcomes(x));

            return games.Select(x => x.GetPlayer2Score()).Sum().ToString();
        }

        public static RockPaperScissorsGame ParseGame(string input)
        {
            var moves = input.Split(" ").Select(x => ParseMove(x[0])).ToArray();
            return new RockPaperScissorsGame(moves[0], moves[1]);
        }

        public static RockPaperScissorsGame ParseGameWithOutcomes(string input)
        {
            var inputAsChars = input.ToCharArray();
            var player1Move = inputAsChars[0];
            var outcome = inputAsChars[2];
            return new RockPaperScissorsGame(ParseMove(player1Move), ParseOutcome(outcome));
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
                var x when x == 'A' || x == 'X' => Move.Rock,
                var x when x == 'B' || x == 'Y' => Move.Paper,
                var x when x == 'C' || x == 'Z' => Move.Scissors,
                _ => throw new NotImplementedException()
            };
        }
    }
}
