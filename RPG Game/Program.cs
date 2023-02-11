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


            // Intro
            Console.WriteLine("Your journey begins now {0}.\n", player.Name);
            Console.WriteLine(new string('-', 120));


            //Create a variable to trakc the first enemy.
            Enemy firstEnemy = new Enemy("Giant Bee Enemy");


            //Perform the battle game loop.
            GameLoop(firstEnemy, random, player,history);


            //Check if the player is dead.
            if (!player.isDead)
            {
                //Player is NOT dead

                //Create a variable to track the Boss.
                Boss boss = new Boss();

                //Perform the battle game loop.
                GameLoop(boss, random, player, history);

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




            //Give player the options to choose from Hisory of his actions , statistics or leave the game.
            Console.WriteLine("\nHistory -> \"H\" \nStatistics -> \"S\"\nExit - 0");

            //Store the player wish to see the "Battle History" or "Statistics"
            string playerWish = Console.ReadLine().ToLower();
            while (playerWish != "h" && playerWish != "s" && playerWish != "0")
            {
                Console.WriteLine("Invalid input. Type again: ");
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
        private static void GameLoop(Enemy enemy, Random random, Player player, History history)
        {
            //Write out to the screen about the enemy attack.
            Console.WriteLine($"{player.Name}, you have encountered a {enemy.Name}!");



            //While the first enemy and player are not dead , repeat the playable cicle.
            while (!enemy.IsDead && !player.isDead)
            {

                //Write out to the screan your options
                Console.WriteLine("What would you like to do ? " +
                    "\n\n 1. Attack " +
                    "\n 2. Defend " +
                    "\n 3. Heal");


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

                            enemy.GetsHitCritical(random.Next(player.MaxAttack, player.MaxAttack));//TODO 
                        }
                        else
                        {
                            enemy.GetsHit(random.Next(1, player.MaxAttack));
                        }
                        break;
                    case "2":
                        Console.WriteLine($"{player.Name}, you choose to Defend from the {enemy.Name}!");
                        player.isGuarding = true;

                        break;
                    case "3":
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