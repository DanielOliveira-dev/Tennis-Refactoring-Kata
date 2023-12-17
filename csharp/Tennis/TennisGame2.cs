using System;
using Tennis.Domain;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Points p1point;
        private Points p2point;
        private readonly string player1Name;
        private readonly string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = Points.Love;
            this.player2Name = player2Name;
            p2point = Points.Love;
        }

        public string GetScore()
        {
            if (p1point == p2point)
            {
                return p1point < Points.Forty ? $"{p1point}-All" : "Deuce";
            }

            if (p1point > Points.Forty || p2point > Points.Forty)
            {
                var pointDifference = p1point - p2point;

                if (Math.Abs(pointDifference) >= 2)
                {
                    return pointDifference > 0 ? $"Win for {player1Name}" : $"Win for {player2Name}";
                }
                else
                {
                    return pointDifference > 0 ? $"Advantage {player1Name}" : $"Advantage {player2Name}";
                }
            }

            return $"{p1point}-{p2point}";
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

