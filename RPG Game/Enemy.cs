namespace RPG_Game
{/// <summary>
/// Represent the base elements of an enemy;
/// </summary>
    internal class Enemy
    {
        /// <summary>
        /// The health of the enemy.
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// The name of the enemy.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Determines if this enemy is dead.
        /// </summary>
        public bool IsDead { get; set; }
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="name">The name we want to give to this enemy.</param>
        public Enemy(string name)
        {
            //Set the enemies' health.
            Health = 100;
            //Set the enemies name.
            Name = name;
        }

        /// <summary>
        /// This gets called when the enemy is hit.
        /// </summary>
        /// <param name="hit_value">The amount of damage the enemy will take.</param>
        public void GetsHit(int hit_value)
        {
            //Subtract the hit value from the health.
            Health -= hit_value;


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
                    "it has {1} health left!", hit_value, Health);
            }
        }
        public void GetsHitCritical(int hit_value)
        {
            //Subtract the hit value from the health.
            Health -= hit_value;


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
                    "it has {1} health left!", hit_value, Health);
            }
        }
        public void GetsTripleHit(int hit_value)
        {
            //Subtract the hit value from the health.
            Health -= hit_value;


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
                    "it has {1} health left!", hit_value, Health);
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
}
