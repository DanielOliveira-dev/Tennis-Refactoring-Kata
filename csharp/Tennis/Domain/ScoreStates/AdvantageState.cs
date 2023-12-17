namespace Tennis.Domain.ScoreStates
{
    public class AdvantageState : IScoreState
    {
        public string GetScore(Player player1, Player player2)
        {
            return player1.Points > player2.Points ? $"Advantage {player1.Name}" : $"Advantage {player2.Name}";
        }
    }
}
