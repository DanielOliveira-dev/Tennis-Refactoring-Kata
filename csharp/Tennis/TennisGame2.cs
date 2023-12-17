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
            if (string.IsNullOrEmpty(player1Name) ||
                string.IsNullOrEmpty(player2Name) ||
                player1Name == player2Name)
            {
                throw new ArgumentException("Player names cannot be null, empty or equal");
            }

            currentScoreState = new EqualPointsState();
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            return currentScoreState.GetScore(player1, player2);
        }

        public void WonPoint(string playerName)
        {
            CheckIfGameStillGoing();
            PlayerScore(playerName);
            HandleCurrentScoreState();
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

        private void CheckIfGameStillGoing()
        {
            if (currentScoreState.GetType() == typeof(WinState))
            {
                throw new ArgumentException("A player has already won");
            }
        }

        private void PlayerScore(string playerName)
        {
            if (player1.Name == playerName)
            {
                player1.Score();
            }
            else if (player2.Name == playerName)
            {
                player2.Score();
            }
            else
            {
                throw new ArgumentException("Incorrect player name");
            }
        }

        #endregion
    }
}

