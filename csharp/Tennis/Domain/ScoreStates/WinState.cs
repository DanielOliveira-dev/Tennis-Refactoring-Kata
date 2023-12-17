namespace Tennis.Domain.ScoreStates
{
    public class WinState : IScoreState
    {
        public string GetScore(Player player1, Player player2)
        {
            return player1.Points > player2.Points ? $"Win for {player1.Name}" : $"Win for {player2.Name}";
        }
    }
}
