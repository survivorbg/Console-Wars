namespace RPG_Game
{
    /// <summary>
    /// Represents the boss enemy in the game.
    /// </summary>
    internal class Boss : Enemy
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Boss() : base("Big Bee Boss")
        {
            //Set the health to be a higher value.
            Health = 150;
            MaxAttack= 17;

        }
    }
}
