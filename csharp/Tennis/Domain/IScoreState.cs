namespace Tennis.Domain
{
    public interface IScoreState
    {
        string GetScore(Player player1, Player player2);
    }
}
