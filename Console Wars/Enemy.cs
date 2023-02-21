namespace RPG_Game
{/// <summary>
/// Represent the base elements of an enemy;
/// </summary>
    internal class Enemy
    {
        //Enemy Name 
        public string Name { get; protected set; }
        //Enemy Hp
        public int Health { get; protected set; } = 100;
        //If enemy is dead
        public bool IsDead { get; set; }
        //Enemy Max Attack
        public int MaxAttack { get; protected set; } = 10;
        public static int Level = 0;


        //Default Constructor
        public Enemy()
        {
            //Generate name for the enemy
            this.Name = GenerateName();
            //Set the HP and MaxAttack according to the level of the enemy
            EnemyIncrease();
            Enemy.Level++;
        }
        //Method to set the HP and the maxAtack according to the enemy level.
        private void EnemyIncrease()
        {
            this.MaxAttack = this.MaxAttack + Level;
            this.Health = this.Health +(5 * Level);
        }
        //Generates name for the enemy from the Enumerator
        private static string GenerateName()
        {
            Random random = new Random();
            return (EnemyCombination)random.Next(0, 4) + " " + (EnemyCombination)random.Next(4, 8);
        }
        /// <summary>
        /// This gets called when the enemy is hit.
        /// </summary>
        /// <param name="hit_value">The amount of damage the enemy will take.</param>
        public void GetsHit(int hit_value)
        {
            //Subtract the hit value from the health.
            Health -= hit_value;
            Statistics.CollectDamageForSingleAttack(hit_value);

            //Check if the enemy is dead.
            if (Health <= 0)
            {
                //The enemy is dead
                IsDead = true;
                Gone();
            }
            else
            {
                //If its not dead , print his health.
                Console.WriteLine("You hit the enemy with {0} damage and " +
                    "he has {1} health left!", hit_value, Health);
            }
        }
        public void GetsHitCritical(int hit_value)
        {
            //Subtract the hit value from the health.
            Health -= hit_value;
            Statistics.CollectDamageForSingleAttack(hit_value);

            //Check if the enemy is dead.
            if (Health <= 0)
            {
                //The enemy is dead
                IsDead = true;
                Gone();
            }
            else
            {
                //If its not dead , print his health.
                Console.Beep(750,100);
                Console.WriteLine("CRITICAL! You hit the enemy with {0} damage and " +
                    "he has {1} health left!", hit_value, Health);
            }
        }
        
        /// <summary>
        /// Called when the enemy is supposed to be gone.
        /// </summary>
        public void Gone()
        {
            //Write to the console that the enemy is gone.
            Console.WriteLine("{0} is gone!", Name);
        }

    }
    public enum EnemyCombination
    {
        Frost = 0,
        Fire = 1,
        Earth = 2,
        Water = 3,
        Cultist = 4,
        Enforcer = 5,
        Warlock = 6,
        Voidwalker = 7
    }

}
