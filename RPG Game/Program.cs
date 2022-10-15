namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            



            //Create and store the random class
            Random random = new Random();




            //Output the text stating that we want the players name
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
            GameLoop(firstEnemy, random, player, 10);





            //Check if the player was the one that died.
            if (!player.isDead)
            {
                //Player is NOT dead

                //Create a variable to trakc the Boss.
                Boss boss = new Boss();



                //Perform the battle game loop.
                GameLoop(boss, random, player, 17);

                if (!player.isDead)
                {
                    //You beat the game.
                    Console.WriteLine("Wohooooo. You've completed the game!");
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

        }











        /// <summary>
        /// The main game loop that allows the player to attack an enemy.
        /// </summary>
        /// <param name="enemy">The enemy the player will attack.</param>
        /// <param name="random">The random number generator we will use to generate random numbers.</param>
        /// <param name="player">The player that we are playing as.</param>
        /// <param name="max_attack_power">The max attack power the enemy has to attack player.</param>
        private static void GameLoop(Enemy enemy, Random random, Player player, int max_attack_power)
        {
            //Write out to the screen about the enemy attack.
            Console.WriteLine("{0}, you have encountered a {1}!", player.Name, enemy.Name);


            //While the first enemy and player are not dead , repeat the playable cicle.
            while (!enemy.IsDead && !player.isDead)
            {
                //Write out to the screan your options
                Console.WriteLine("What would you like to do ? \n\n 1.Single " +
                "Attack \n 2.Three Strike Attack \n 3.Defend \n 4.Heal");


                //Store what action player choose
                string playerAction = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine(new string('-', 120));
                //Check what action the player took against the first enemy.
                switch (playerAction)
                {
                    case "1":
                        Console.WriteLine("{0}, you choose to hit the {1} with a Single Attack!", player.Name, enemy.Name);
                        //Apply the atack damage to the enemy.
                        //firstEnemy.Health -= random.Next(1,15) ;
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
                        Console.WriteLine("{0}, you choose to hit the {1} with Three Strike Attack!", player.Name, enemy.Name);
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
                        Console.WriteLine("{0}, you choose to Defend from the {1}!", player.Name, enemy.Name);
                        player.isGuarding = true;
                        break;
                    case "4":
                        Console.WriteLine("{0}, you choose to Heal!", player.Name);
                        if (random.Next(0, 100) >= 90)
                        {
                            player.GetsCriticalHealed(random.Next(15, 20));

                        }
                        else
                        {
                            player.GetsHealed(random.Next(1, 15));

                        }

                        break;
                    case "kill":
                        enemy.IsDead = true;
                        break;
                    case "Kill":
                        enemy.IsDead = true;
                        break;
                    default:
                        Console.WriteLine("You choose something else.");
                        break;
                }

                //Have the enemy attack the player.
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