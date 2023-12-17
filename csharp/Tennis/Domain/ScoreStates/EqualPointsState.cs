namespace Tennis.Domain.ScoreStates
{
    public class EqualPointsState : IScoreState
    {
        public string GetScore(Player player1, Player player2)
        {
            return player1.Points < Points.Forty ? $"{player1.Points}-All" : "Deuce";
        }
    }
}
