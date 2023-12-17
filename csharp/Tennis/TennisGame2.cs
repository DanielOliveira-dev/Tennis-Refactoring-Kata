using System;
using Tennis.Domain;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame2(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            if (player1.Points == player2.Points)
            {
                return player1.Points < Points.Forty ? $"{player1.Points}-All" : "Deuce";
            }

            if (player1.Points > Points.Forty || player2.Points > Points.Forty)
            {
                var pointDifference = player1.Points - player2.Points;

                if (Math.Abs(pointDifference) >= 2)
                {
                    return pointDifference > 0 ? $"Win for {player1.Name}" : $"Win for {player2.Name}";
                }
                else
                {
                    return pointDifference > 0 ? $"Advantage {player1.Name}" : $"Advantage {player2.Name}";
                }
            }

            return $"{player1.Points}-{player2.Points}";
        }

        public void WonPoint(string playerName)
        {
            if (player1.Name == playerName)
            {
                player1.Score();
            }
            else
            {
                player2.Score();
            }
        }

    }
}

