internal static class SnakesAndLadders
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Snakes and Ladders program!");

        const int maxTileNumber = 100;
        int playerOnePosition = 0; // UC1 Snake and ladder game played with single player at start position 0.
        int playerTwoPosition = 0;
        int oldPlayerOnePosition = 0;
        int oldPlayerTwoPosition = 0;
        int dieRollTrackerOne = 0;
        int dieRollTrackerTwo = 0;
        int chanceTracker = 1;


        Console.WriteLine("Enter player one name : ");
        string playerOneName = Console.ReadLine();
        Console.WriteLine("Enter player two name : ");
        string playerTwoName = Console.ReadLine();


        while (playerOnePosition < maxTileNumber && playerTwoPosition < maxTileNumber)
        {
            if (chanceTracker % 2 ==0) // UC7 Added Player Two
            {
                dieRollTrackerTwo++;
                oldPlayerTwoPosition = playerTwoPosition;
                playerTwoPosition = Player(playerTwoName, playerTwoPosition);

                if (playerTwoPosition < oldPlayerTwoPosition)
                {
                    chanceTracker++;
                }
                else if (playerTwoPosition == oldPlayerTwoPosition)
                {
                    chanceTracker++;
                }
                else
                {
                    chanceTracker += 2;
                }

                Console.WriteLine(playerTwoName + " was at {0} and now is at {1}." , oldPlayerTwoPosition , playerTwoPosition);
                Console.WriteLine("Die roll count : {0} \n", dieRollTrackerTwo);
            }
            else // Player One
            {
                dieRollTrackerOne++;
                oldPlayerOnePosition = playerOnePosition;
                playerOnePosition = Player(playerOneName, playerOnePosition);

                if (playerOnePosition < oldPlayerOnePosition)
                {
                    chanceTracker++;
                }
                else if (playerOnePosition == oldPlayerOnePosition)
                {
                    chanceTracker++;
                }
                else
                {
                    chanceTracker += 2;
                }

                Console.WriteLine(playerOneName + " was at {0} and now is at {1}.", oldPlayerOnePosition, playerOnePosition);
                Console.WriteLine("Die roll count : {0} \n" , dieRollTrackerOne);
            }
        }

        if (playerOnePosition == maxTileNumber)
        {
            Console.WriteLine(playerOneName + " has won!!");
        }
        else
        {
            Console.WriteLine(playerTwoName + " has won!!");
        }


    }
    static int Player(string player, int newPosition)
    {
        int dice = 0;
        const int maxTileNumber = 100;
        int oldPosition = 0;
        Random random = new Random();
        int decider = random.Next(0, 3); //UC3 Player checks for No play, Ladder or Snake
        switch (decider)
        {
            case 0: // No play
                Console.WriteLine(player + " got no play. Wait for another turn.");
                break;

            case 1: // Ladder
                Console.WriteLine("Great! " + player + " found a ladder.");
                dice = random.Next(1, 7); // UC2 The player rolls a die to get a number between 1 to 6.
                oldPosition = newPosition;
                newPosition += dice;
                if (newPosition > maxTileNumber) //UC5 If player position goes above 100 then player stays in the same position
                {
                    Console.WriteLine("Your die roll is {0} which is more than required, staying in the same position as before.", dice);
                    newPosition = oldPosition;
                }
                break;

            case 2: // Snake
                Console.WriteLine("SSSSS! " + player + " has landed on a snake !");
                dice = random.Next(1, 7); // UC2 The player rolls a die to get a number between 1 to 6.
                oldPosition = newPosition;
                newPosition -= dice;

                if (newPosition < 0) // UC4 If player position moves below 0 player starts from 0th position.
                {
                    newPosition = 0;
                }
                break;

        }


            return newPosition;
        
    }
}