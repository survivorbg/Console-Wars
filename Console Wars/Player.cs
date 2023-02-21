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
        public int Kills { get; set; }
        public int CritChance { get; set; }
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
            MaxAttack = 45;
            Kills = 0;
            CritChance = 5;
        }
        /// <summary>
        /// This is called when the player is hit.
        /// </summary>
        /// <param name="hit_value">The damage that player takes.</param>
        public void GetsHit(int hitValue)
        {
            //Check if the player is guarding.
            if (isGuarding)
            {
                //Print that player guarded the attack.
                Console.WriteLine($"{Name} just guarded the blow! You blocked {hitValue} damage!");
                isGuarding = false; //reset the guarding stance
            }
            else
            {
                Health -= hitValue;
                Statistics.CollectEnemyDamage(hitValue);
                //Check if the player is dead
                if (Health <= 0)
                {
                    //Set the boolean to true.
                    isDead = true;
                    //Print the player is dead
                    Console.WriteLine($"The enemy hit you with {hitValue} damage!");
                    Gone();
                }
                else
                {
                    Console.WriteLine($"You were hit with {hitValue} damage and you have {Health} health left.");

                }
            }
        }

        public void GetsCriticallyHit(int hitValue)
        {
            //Check if the player is guarding.
            if (isGuarding)
            {
                //Print that player guarded the attack.
                Console.WriteLine($"{Name} just guarded the blow! You blocked {hitValue} damage!");
                isGuarding = false;
            }
            else
            {
                Health -= hitValue;
                Statistics.CollectEnemyDamage(hitValue);
                //Check if the player is dead
                if (Health <= 0)
                {
                    //Set the boolean to true.
                    isDead = true;
                    //Print the player is dead
                    Console.WriteLine($"The enemy CRITICALLY hit you with {hitValue} damage!");
                    Gone();
                }
                else
                {
                    Console.WriteLine($"You were CRITICALLY hit with {hitValue} damage and you have {Health} health left.");
                }
            }
        }
        /// <summary>
        /// This is called when the player is healed.
        /// </summary>
        /// <param name="healed_value">The amount that player is healed with.</param>
        public void GetsHealed(int healedValue)
        {
            Health += healedValue;
            Statistics.CollectHeal(healedValue);
            if (Health >= 100)
            {
                Health = 100;
                Console.WriteLine($"You were healed with {healedValue} points and now you have MAX HP(100)!");

            }
            else
            {
                Console.WriteLine($"You were healed with {healedValue} points and now you have {Health} health.");
            }
        }
        public void GetsCriticalHealed(int healedValue)
        {
            Statistics.CollectHeal(healedValue);
            Health += healedValue;
            if (Health >= 100)
            {
                Health = 100;
                Console.WriteLine($"You were CRITICALLY healed with {healedValue} points and now you have MAX HP(100)!");

            }
            else
            {
                Console.WriteLine($"You were CRITICALLY healed with {healedValue} points and now you have {Health} health.");
            }
        }
        /// <summary>
        /// Called when the player is supposed to be gone.
        /// </summary>
        public void Gone()
        {
            Console.WriteLine($"{Name}, you are dead!");
        }
        public void PlayerEarnXP()
        {
            Experience += 105; //Temporary, lower it after
            Kills++;
            CritChance += 2;
            if(Experience>= 100)
            {
                Level++;
                Experience -= 100;
                MaxAttack += 5;
                Console.WriteLine($"Congratulations, Level {Level}! You are stronger now!");
            }
        }
    }
}