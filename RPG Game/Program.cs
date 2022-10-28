namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Create a history variable, so we can track the history.
            History history = new History();

            //Create and store the random class
            Random random = new Random();


            //Get player's name
            Console.Write("Enter your name: ");


            //Create the player character
            Player player = new Player()
            {
                Name = Console.ReadLine()
            };
            Console.WriteLine();


            // Let the player know his name
            Console.WriteLine("Your journey begins now {0}.\n", player.Name);
            Console.WriteLine(new string('-', 120));


            //Create a variable to trakc the first enemy.
            Enemy firstEnemy = new Enemy("Giant Bee Enemy");


            //Perform the battle game loop.
            GameLoop(firstEnemy, random, player, 10, history);


            //Check if the player is dead.
            if (!player.isDead)
            {
                //Player is NOT dead

                //Create a variable to track the Boss.
                Boss boss = new Boss();


                //Perform the battle game loop.
                GameLoop(boss, random, player, 17, history);

                if (!player.isDead)
                {
                    //You beat the game.
                    Console.WriteLine("Good Job! You've completed the game!");
                }
                else
                {
                    //The game is over.
                    GameOver();
                }




            }
            else
            {
                //Player is dead
                GameOver();
            }
            //TODO - да го сложа в горния иф 
            Console.WriteLine("\nHistory -> \"H\" \nStatistics -> \"S\"\nExit - 0");//Ask the player if he want to see the history of his actions during the battles.

            //Store the player wish to see the "Battle History"
            string playerWish = Console.ReadLine().ToLower();
            while (playerWish != "h" && playerWish != "s" && playerWish != "0")
            {
                Console.WriteLine("Invalid input. Do you want to see a history of your actions?");
                playerWish = Console.ReadLine().ToLower();
            }

            if (playerWish == "h")
            {
                history.ShowHistoryOfPlayerActions();
            }
            else if (playerWish == "s")
            {
                Statistics.ShowStatistics();
            }
            else if (playerWish == "0")
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
        /// <param name="max_attack_power">The max attack power the enemy has to attack player.</param>
        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power, History history)
        {
            //Write out to the screen about the enemy attack.
            Console.WriteLine($"{player.Name}, you have encountered a {enemy.Name}!");



            //While the first enemy and player are not dead , repeat the playable cicle.
            while (!enemy.IsDead && !player.isDead)
            {

                //Write out to the screan your options
                Console.WriteLine("What would you like to do ? " +
                    "\n\n 1.Single Attack " +
                    "\n 2.Three Strike Attack " +
                    "\n 3.Defend " +
                    "\n 4.Heal");


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
                        Console.WriteLine($"{player.Name}, you choose to hit the {enemy.Name} with a Single Attack!");
                        //Apply the atack damage to the enemy.

                        ;
                        if (random.Next(0, 100) >= 95)
                        {

                            enemy.GetsHitCritical(random.Next(20, 20));
                        }
                        else
                        {
                            enemy.GetsHit(random.Next(1, 15));
                        }
                        break;
                    case "2":
                        Console.WriteLine($"{player.Name}, you choose to hit the {enemy.Name} with Three Strike Attack!");
                        //Loop three time to perform our multi(3) attack.

                        for (int i = 0; i < 3; i++)
                        {
                            if (!enemy.IsDead)
                            {
                                if (random.Next(0, 100) >= 90)
                                {
                                    enemy.GetsHitCritical(random.Next(20, 20));
                                }
                                else
                                {
                                    enemy.GetsHit(random.Next(1, 15));
                                }
                            }
                        }

                        break;
                    case "3":
                        Console.WriteLine($"{player.Name}, you choose to Defend from the {enemy.Name}!");
                        player.isGuarding = true;

                        break;
                    case "4":
                        Console.WriteLine($"{player.Name}, you choose to Heal!");
                        if (random.Next(0, 100) >= 90)
                        {
                            player.GetsCriticalHealed(random.Next(15, 20));

                        }
                        else
                        {
                            player.GetsHealed(random.Next(1, 15));

                        }

                        break;

                    //cheatcode - if you enter command Kill - the enemy is automatically dead.
                    case "kill":
                        enemy.IsDead = true;
                        enemy.Gone();
                        break;

                    default:
                        //Tell the player that he entered invalid action.
                        Console.WriteLine("You choose something else.");
                        break;

                }

                //Check again if the enemy is dead and have the enemy attack the player.
                if (!enemy.IsDead)
                {
                    if (random.Next(1, 10) >= 9)
                    {
                        player.GetsCriticallyHit(random.Next(max_attack_power, max_attack_power + 10));
                    }
                    else
                    {
                        player.GetsHit(random.Next(1, max_attack_power));
                    }
                }
            }

        }
        private static void GameOver()
        {
            Console.WriteLine("Game Over!");
        }
    }

}