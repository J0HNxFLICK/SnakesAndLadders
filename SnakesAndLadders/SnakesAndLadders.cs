namespace SnakesAndLadders
{
    internal class SnakesAndLadders
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snakes and Ladders program!");
            Random random = new Random();
            const int maxTileNumber = 100;
            int dice = 0;
            int oldPosition = 0;
            int playerPosition = 0; // UC1 Snake and ladder game played with single player at start position 0
            

            Console.WriteLine("Enter player name : ");
            string playerOneName = Console.ReadLine();

            while (playerPosition < maxTileNumber)
            {
                int decider = random.Next(0, 3); //UC3 Player checks for No play, Ladder or Snake
                switch (decider)
                {
                    case 0:
                        Console.WriteLine(playerOneName + " got no play.\n");
                        break;

                    case 1:
                        Console.WriteLine("Great! " + playerOneName + " found a ladder.");
                        dice = random.Next(1, 7); // UC2 The player rolls a die to get a number between 1 to 6.
                        oldPosition = playerPosition;
                        playerPosition += dice;

                        if (playerPosition > maxTileNumber) //UC5 If player position goes above 100 then player stays in the same position
                        {
                            Console.WriteLine("Your die roll is {0} which is more than required, staying in the same position as before.", dice);
                            playerPosition = oldPosition;
                        }

                        Console.WriteLine("{0} moved from {1} to {2}\n" , playerOneName , oldPosition, playerPosition);
                        break;

                    case 2:
                        Console.WriteLine("SSSSS! " + playerOneName + " has landed on a snake !");
                        dice = random.Next(1, 7); // UC2 The player rolls a die to get a number between 1 to 6.
                        oldPosition= playerPosition;
                        playerPosition -= dice;

                        if (playerPosition < 0) // UC4 If player position moves below 0 player starts from 0th position.
                        {
                            playerPosition = 0;
                        }

                        Console.WriteLine("{0} went back from {1} to {2}\n", playerOneName, oldPosition , playerPosition);
                        break;

                }

            }

        }
    }
}