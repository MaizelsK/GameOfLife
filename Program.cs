namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new GameManager(30);
            gameManager.Start();
        }
    }
}
