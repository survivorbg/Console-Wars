using System.Security.Cryptography;

namespace RPG_Game
{
    /// <summary>
    /// This class represents the playable character.
    /// </summary>
    public class Player
    {
        
        public List<string> playerActions = new List<string>();
        /// <summary>
        /// This represents the players health values.
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This shows if the player is dead.
        /// </summary>
        public bool isDead;
        /// <summary>
        /// This shows if the player is guarding.
        /// </summary>
        public bool isGuarding;
        /// <summary>
        /// This shows the player XP.
        /// </summary>
        public double Experience { get; set; }
        /// <summary>
        /// Player level.
        /// </summary>
        public int Level { get; set; }
        public int MaxAttack { get; set; }
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Player()
        {
            //set the health value to 100.
            Health = 100;
            //set the starting xp - 0
            Experience= 0;
            //set the starting level - 1
            Level = 1;
            MaxAttack = 15;
        }
        /// <summary>
        /// This is called when the player is hit.
        /// </summary>
        /// <param name="hit_value">The damage that player takes.</param>
        public void GetsHit(int hit_value)
        {
            //Check if the player is guarding.
            if (isGuarding)
            {
                //Print that player guarded the attack.
                Console.WriteLine("{0} just guarded the blow!", Name);
                isGuarding = false; //reset the guarding stance
            }
            else
            {
                Health -= hit_value;
                Statistics.CollectEnemyDamage(hit_value);
                //Check if the player is dead
                if (Health <= 0)
                {
                    //Set the boolean to true.
                    isDead = true;
                    //Print the player is dead
                    Console.WriteLine("The enemy hit you with {0} damage!", hit_value);
                    Gone();
                }
                else
                {
                    Console.WriteLine("You were hit with {0} damage and you have {1} health left.", hit_value, Health);

                }
            }
        }

        public void GetsCriticallyHit(int hit_value)
        {
            //Check if the player is guarding.
            if (isGuarding)
            {
                //Print that player guarded the attack.
                Console.WriteLine("{0} just guarded the blow!", Name);
                isGuarding = false;
            }
            else
            {
                Health -= hit_value;
                Statistics.CollectEnemyDamage(hit_value);
                //Check if the player is dead
                if (Health <= 0)
                {
                    //Set the boolean to true.
                    isDead = true;
                    //Print the player is dead
                    Console.WriteLine("The enemy CRITICALLY hit you with {0} damage!", hit_value);
                    Gone();
                }
                else
                {
                    Console.WriteLine("You were CRITICALLY hit with {0} damage and you have {1} health left.", hit_value, Health);
                }
            }
        }
        /// <summary>
        /// This is called when the player is healed.
        /// </summary>
        /// <param name="healed_value">The amount that player is healed with.</param>
        public void GetsHealed(int healed_value)
        {
            Health += healed_value;
            Statistics.CollectHeal(healed_value);
            if (Health >= 100)
            {
                Health = 100;
                Console.WriteLine("You were healed with {0} points and now you have MAX HP(100)!", healed_value);

            }
            else
            {
                Console.WriteLine("You were healed with {0} points and now you have {1} health.", healed_value, Health);
            }
        }
        public void GetsCriticalHealed(int healed_value)
        {
            Statistics.CollectHeal(healed_value);
            Health += healed_value;
            if (Health >= 100)
            {
                Health = 100;
                Console.WriteLine("You were CRITICALLY healed with {0} points and now you have MAX HP(100)!", healed_value);

            }
            else
            {
                Console.WriteLine("You were CRITICALLY healed with {0} points and now you have {1} health.", healed_value, Health);
            }
        }
        /// <summary>
        /// Called when the player is supposed to be gone.
        /// </summary>
        public void Gone()
        {
            Console.WriteLine($"{Name}, you are dead!");
        }
        /// <summary>
        /// Called every time when the player choose an action
        /// </summary>
        /// <param name="action_count">action number</param>
        /// <param name="action">action type</param>
        /// <returns></returns>
        public void CollectPlayerActionsForHistory(string action)
        {
            var actionType = "";
            switch (action)
            {
                case "1":
                    actionType = "Single Attack";
                    break;
                case "2":
                    actionType = "Three Strike Attack";
                    break;
                case "3":
                    actionType = "Defend";
                    break;
                case "4":
                    actionType = "Heal";
                    break;
                default:
                    actionType = "Invalid Action";
                    break;
            }
            playerActions.Add(actionType);
        }
        public void ShowHistoryOfPlayerActions()
        {
            var count = 0;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("HISTORY OF PLAYER ACTIONS: ");
            Console.WriteLine();
            foreach (var action in playerActions)
            {
                Console.WriteLine($"{++count} --> {action}");
            }
        }
        public void PlayerEarnXP()
        {
            Experience += 105; //Temporary, lower it after
            if(Experience>= 100)
            {
                Level++;
                Experience -= 100;
                MaxAttack *= 5;
                Console.WriteLine($"Congratulations, Level {Level}! You are stronger now!");
            }
        }
    }
}