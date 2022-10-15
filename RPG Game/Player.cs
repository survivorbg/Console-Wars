namespace RPG_Game
{
    /// <summary>
    /// This class represents the playable character.
    /// </summary>
    public class Player
    {
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
        /// This show if the player is guarding.
        /// </summary>
        public bool isGuarding;
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Player()
        {
            //set the health value to 100.
            Health = 100;
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
                isGuarding = false;
            }
            else
            {
                Health -= hit_value;
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
            Console.WriteLine("{0}, you are dead!", Name);
        }
    }
}