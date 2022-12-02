using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Solutions
{
    public class RockPaperScissorsGame
    {
        public Move Player1Move { get; set; }
        public Move Player2Move { get; set; }

        private static readonly List<Move> _moveHeirarchy = new List<Move>() 
        { 
            Move.Rock,
            Move.Paper,
            Move.Scissors
        };

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
            
            var player2ShouldWin = desiredOutcome == Outcome.Player2Win;
            return GetResponse(player1Move, player2ShouldWin);
        }

        public Move GetResponse(Move move, bool shouldWin)
        {
            var moveIndex = _moveHeirarchy.IndexOf(move);
            var stepDirection = shouldWin ? 1 : -1;
            var winningMoveIndex = (moveIndex + _moveHeirarchy.Count + stepDirection) % _moveHeirarchy.Count;
            return _moveHeirarchy[winningMoveIndex];
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

            return Player2Move == GetResponse(Player1Move, shouldWin: true) ? Outcome.Player2Win : Outcome.Player1Win;
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
