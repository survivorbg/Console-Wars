namespace Console_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Create a history variable to track the game history.
            History history = new History();

            //Create and store the random class
            Random random = new Random();

            // Get player's name and create the player character.
            Console.Write("Enter your name: ");
            Player player = new Player()
            {
                Name = Console.ReadLine()
            };
            Console.WriteLine();


            // Print the game intro.
            Console.WriteLine("Your journey begins now {0}.\n", player.Name);
            Console.WriteLine(new string('-', 120));



            while (!player.isDead)
            {

                // If the player killed four enemies, initiate a boss battle.
                if (player.Kills == 4 && !player.isDead)
                {
                    // Create a variable to track the Boss enemy.
                    Boss boss = new Boss();

                    //Perform the battle game loop.
                    GameLoop(boss, random, player, history);

                    if (!player.isDead)
                    {
                        // The player won the game.
                        Console.WriteLine("Good Job! You've completed the game!");
                        break;
                    }
                    else
                    {
                        // The player lost the game.
                        GameOver();
                        break;
                    }
                }
                else
                {
                    //Create a variable to track the first enemy.
                    Enemy firstEnemy = new Enemy();

                    //Perform the battle game loop.
                    GameLoop(firstEnemy, random, player, history);
                }

            }



            //Give player the options to choose from Hisory of his actions , statistics or leave the game.
            Console.WriteLine("\nHistory -> \"H\" \nStatistics -> \"S\"\nExit - 0");

            // Store the player's choice to see the "Battle History" or "Statistics".
            string playerChoice = Console.ReadLine().ToLower();

            // Validate the player's input.
            while (playerChoice != "h" && playerChoice != "s" && playerChoice != "0")
            {
                Console.WriteLine("Invalid input. Type again: ");
                playerChoice = Console.ReadLine().ToLower();
            }
            // Show the player's requested information.
            if (playerChoice == "h")
            {
                history.ShowHistoryOfPlayerActions();
                Console.ReadKey();
            }
            else if (playerChoice == "s")
            {
                Statistics.ShowStatistics();
                Console.ReadKey();
            }
            else if (playerChoice == "0")
            {
                Console.WriteLine("THANKS FOR PLAYING!");
                return;
            }
        }


        /// <summary>
        /// The main game loop that allows the player to attack an enemy.
        /// </summary>
        /// <param name="enemy">The enemy which the player will attack.</param>
        /// <param name="random">The random number generator we will use to generate random numbers.</param>
        /// <param name="player">The player that we are playing as.</param>
        /// <param name="history">The game history tracker.</param>
        private static void GameLoop(Enemy enemy, Random random, Player player, History history)
        {
            // Print the enemy encounter message.
            Console.WriteLine($"{player.Name}, you've encountered the {enemy.Name}!");



            //While the first enemy and player are not dead , repeat the playable cicle.
            while (!enemy.IsDead && !player.isDead)
            {

                // Print the player's options.
                Console.WriteLine("What would you like to do ? " +
                    "\n\n 1. Attack " +
                    "\n 2. Defend " +
                    "\n 3. Heal" +
                    "\n 4. DoT");


                //Store what action the player choose
                string playerAction = Console.ReadLine().ToLower();
                Console.WriteLine();
                Console.WriteLine(new string('-', 120));


                //Store all the player actions for the "History"
                history.CollectPlayerActionsForHistory(playerAction);

                //Check what action the player took against the first enemy.
                switch (playerAction)
                {

                    case "1":
                        Console.WriteLine($"\n{player.Name}, you choose to hit the {enemy.Name} with a Single Attack!");
                        //Apply the atack damage to the enemy.
                        enemy.GetsHitNormalOrCrit(player.CritChance, player.MaxAttack);
                        break;
                    case "2":
                        Console.WriteLine($"\n{player.Name}, you choose to Defend from the {enemy.Name}!");
                        player.isGuarding = true;

                        break;
                    case "3":
                        Console.WriteLine($"\n{player.Name}, you choose to Heal!");
                        if (random.Next(0, 100) >= 90)
                        {
                            player.GetsCriticalHealed(random.Next(15, 20));

                        }
                        else
                        {
                            player.GetsHealed(random.Next(1, 15));

                        }

                        break;
                    case "4":
                        if (!enemy.ActiveDoT)
                        {
                            Console.WriteLine($"\n{player.Name}, you choose to hit the {enemy.Name} with a DoT! It will last 3 rounds.");
                            enemy.ActiveDoT = true;
                        }
                        else
                        {
                            enemy.DoTAttack();
                        }

                        break;

                    //cheatcode - if you enter command Kill - the enemy is automatically dead.
                    case "kill":
                        enemy.IsDead = true;
                        enemy.Gone();
                        break;

                    default:
                        //Tell the player that he entered invalid action.
                        Console.WriteLine("Missed opportunity! Invalid Input! ");
                        break;

                }

                //Check again if the enemy is dead and have the enemy attack the player.
                if (!enemy.IsDead)
                {
                    if (random.Next(1, 10) >= 9)
                    {
                        player.GetsCriticallyHit(random.Next(enemy.MaxAttack, enemy.MaxAttack + 10));
                    }
                    else
                    {
                        player.GetsHit(random.Next(1, enemy.MaxAttack));
                    }
                }
                else
                {
                    player.PlayerEarnXP();
                }
            }

        }
        private static void GameOver()
        {
            Console.WriteLine("Game Over!");
        }
    }
}