namespace SnakesAndLadders
{
    internal class SnakesAndLadders
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snakes and Ladders program!");
            Random random = new Random();
            const int maxTileNumber = 100;
            int playerPosition = 0; // UC1 Snake and ladder game played with single player at start position 0

            Console.WriteLine("Enter player name : ");
            string playerName = Console.ReadLine();

            while (playerPosition <= maxTileNumber)
            {
                playerPosition += random.Next(1,7); // UC2 The player rolls a die to get a number between 1 to 6.
            }

        }
    }
}