using System;
using Tennis.Domain;
using Tennis.Domain.ScoreStates;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private IScoreState currentScoreState;
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame2(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            HandleCurrentScoreState();

            return currentScoreState.GetScore(player1, player2);
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

        #region PrivateMethods

        private void HandleCurrentScoreState()
        {
            if (PlayersHaveEqualPoints())
            {
                currentScoreState = new EqualPointsState();
            }
            else if (AnyPlayerReachedAboveForty())
            {
                HandleAdvantageOrWinState();
            }
            else
            {
                currentScoreState = new RegularState();
            }
        }

        private bool PlayersHaveEqualPoints()
        {
            return player1.Points == player2.Points;
        }

        private bool AnyPlayerReachedAboveForty()
        {
            return player1.Points > Points.Forty || player2.Points > Points.Forty;
        }

        private void HandleAdvantageOrWinState()
        {
            var pointDifference = player1.Points - player2.Points;
            if (Math.Abs(pointDifference) >= 2)
            {
                currentScoreState = new WinState();
            }
            else
            {
                currentScoreState = new AdvantageState();
            }
        }

        #endregion
    }
}

