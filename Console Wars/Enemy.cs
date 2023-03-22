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
        //If There is an active DoT on the enemy 
        public bool ActiveDoT { get; set; }
        //Follows the remaining round for the DoT
        public int RemainingRounds { get; protected set; } = 3; //when new spawn it will have 3 remaining rounds again
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

        public void GetsHitNormalOrCrit(int playerCritChance, int playerMaxAttack)
        {
            Random random = new Random();
            bool isCritical = false;
            if (random.Next(0, 100) <= playerCritChance)
            {
                isCritical = true;
                GetsHit(playerMaxAttack,isCritical);
            }
            else
            {
                int hitValue = random.Next(1, playerMaxAttack);
                GetsHit(hitValue,isCritical);
            }


        }
        //When in combination with normal attack.
        public void DoTAttack(bool isDotActive,int hitValue)
        {
            if (isDotActive)
            {
                Health -= 5;
                RemainingRounds--;
            }
        }
        //When you try to apply DoT when you already have an active DoT
        public void DoTAttack()
        {
            Console.WriteLine($"\nInvalid action! You still have an active DoT from previous round!");
            Health -= 5;
            RemainingRounds--;
            if (Health <= 0)
            {
                //If the enemy dies before the DoT ends
                ActiveDoT = false;
                //The enemy is dead
                IsDead = true;
                Gone();
            }
            else
            {
                Console.WriteLine($"You hit the enemy with 5 damage over time and he has {Health} health left!");
                if (RemainingRounds == 0)
                {
                    Console.WriteLine("DoT has ended!");
                    ActiveDoT = false;
                    RemainingRounds = 3;
                }
            }
        }
        //Enemy gets hit 
        protected void GetsHit(int hitValue,bool isCritical)
        {
            //Subtract the hit value from the health.
            Health -= hitValue;
            Statistics.CollectDamageForSingleAttack(hitValue);

            DoTAttack(ActiveDoT, hitValue);

            //Check if the enemy is dead.
            if (Health <= 0)
            {
                //If the enemy dies before the DoT ends
                ActiveDoT = false;
                //The enemy is dead
                IsDead = true;
                Gone();
            }
            else
            {
                if (ActiveDoT)
                {
                    if (!isCritical)
                    {

                        //If its not dead , print his health.
                        Console.WriteLine($"You hit the enemy with {hitValue}(+5 DoT) damage and he has {Health} health left!");
                        if (RemainingRounds == 0)
                        {
                            Console.WriteLine("DoT has ended!");
                            ActiveDoT = false;
                            RemainingRounds = 3;
                        }
                    }
                    else
                    {
                        //If its not dead , print his health annd announce - its critical.
                        Console.Beep(750, 100);
                        Console.WriteLine($"CRITICAL! You hit the enemy with {hitValue}(+5 DoT) damage and he has {Health} health left!");
                        if (RemainingRounds == 0)
                        {
                            Console.WriteLine("DoT has ended!");
                            ActiveDoT = false;
                            RemainingRounds = 3;
                        }
                    }
                }
                else
                {
                    if (!isCritical)
                    {

                        //If its not dead , print his health.
                        Console.WriteLine("You hit the enemy with {0} damage and " +
                            "he has {1} health left!", hitValue, Health);
                    }
                    else
                    {
                        //If its not dead , print his health annd announce - its critical.
                        Console.Beep(750, 100);
                        Console.WriteLine("CRITICAL! You hit the enemy with {0} damage and " +
                            "he has {1} health left!", hitValue,Health);
                    }
                }
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
