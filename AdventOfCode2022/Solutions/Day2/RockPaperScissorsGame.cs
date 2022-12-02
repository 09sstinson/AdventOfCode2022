using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class RockPaperScissorsGame
    {
        public Move Player1Move { get; set; }
        public Move Player2Move { get; set; }

        public RockPaperScissorsGame(Move player1Move, Move player2Move)
        {
            Player1Move = player1Move;
            Player2Move = player2Move;
        }

        public RockPaperScissorsGame(Move player1Move, Outcome desiredOutcome)
        {
            Player1Move = player1Move;
            Player2Move = GetPlayer2MoveFromOutcome(player1Move, desiredOutcome);
        }

        private Move GetPlayer2MoveFromOutcome(Move player1Move, Outcome desiredOutcome)
        {
            if (desiredOutcome == Outcome.Draw)
            {
                return player1Move;
            }
            
            // TODO do something cleverer here
            var player1ShouldWin = desiredOutcome == Outcome.Player1Win;
            return player1Move switch
            {
                Move.Rock when player1ShouldWin => Move.Scissors,
                Move.Rock when !player1ShouldWin => Move.Paper,
                Move.Paper when player1ShouldWin => Move.Rock,
                Move.Paper when !player1ShouldWin => Move.Scissors,
                Move.Scissors when player1ShouldWin => Move.Paper,
                Move.Scissors when !player1ShouldWin => Move.Rock,
                _ => throw new NotImplementedException(),
            };
        }

        public int GetPlayer2Score()
        {
            return (int)Player2Move + (int)GetOutcome();
        }

        public Outcome GetOutcome()
        {
            if (Player1Move == Player2Move)
            {
                return Outcome.Draw;
            }

            // TODO do something cleverer here
            if (Player1Move == Move.Rock && Player2Move == Move.Scissors)
            {
                return Outcome.Player1Win;
            }
            if (Player1Move == Move.Paper && Player2Move == Move.Rock)
            {
                return Outcome.Player1Win;
            }
            if (Player1Move == Move.Scissors && Player2Move == Move.Paper)
            {
                return Outcome.Player1Win;
            }

            return Outcome.Player2Win;
        }
    }

    public enum Outcome
    {
        Player2Win = 6,
        Draw = 3,
        Player1Win = 0,
    }

    public enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}
