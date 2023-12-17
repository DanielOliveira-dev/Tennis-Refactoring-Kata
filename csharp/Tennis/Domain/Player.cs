namespace Tennis.Domain
{
    public class Player
    {
        public Points Points { get; private set; } = Points.Love;
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public void Score()
        {
            Points++;
        }
    }
}
