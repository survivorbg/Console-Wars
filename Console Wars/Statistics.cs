namespace Console_Wars
{
    internal class Statistics
    {
        /// <summary>
        /// Store all damages of the player from single attack.
        /// </summary>
        public static List<int> playerDamageFromSingleAttack = new List<int>();
        /// <summary>
        /// Store all player heals.
        /// </summary>
        public static List<int> playerHeals = new List<int>();
        /// <summary>
        /// Stole all enemy damages to the player.
        /// </summary>
        public static List<int> enemyDamage = new List<int>();

        public static void CollectDamageForSingleAttack(int hit_value)
        {
            playerDamageFromSingleAttack.Add(hit_value);
        }
        public static void CollectHeal(int healed_value)
        {
            playerHeals.Add(healed_value);
        }
        public static void CollectEnemyDamage(int hit_value)
        {
            enemyDamage.Add(hit_value);
        }
        public static void ShowStatistics()
        {
            Console.WriteLine();
            Console.WriteLine("STATISTICS:");
            Console.WriteLine();
            if (playerDamageFromSingleAttack.Count > 0) { Console.WriteLine($"Player's biggest hit: {playerDamageFromSingleAttack.Max()}"); }
            else { Console.WriteLine("Тhe player has no damage recorded."); }
            if (playerHeals.Count > 0) { Console.WriteLine($"Player's biggest heal: {playerHeals.Max()}"); }
            else { Console.WriteLine("Тhe player has no healing recorded."); }
            if (enemyDamage.Count > 0) { Console.WriteLine($"Enemy's biggest hit: {enemyDamage.Max()}"); }
            else { Console.WriteLine("Тhe enemy has no damage recorded."); }
            if (playerDamageFromSingleAttack.Count > 0) { Console.WriteLine($"Player's average damage: {playerDamageFromSingleAttack.Average():f2}"); }
            else { Console.WriteLine("Тhe player has no damage recorded."); }
            if (playerHeals.Count > 0) { Console.WriteLine($"Player's average heal: {playerHeals.Average():f2}"); }
            else { Console.WriteLine("Тhe player has no healing recorded."); }
            if (enemyDamage.Count > 0) { Console.WriteLine($"Enemy's average damage: {enemyDamage.Average():f2}"); }
            else { Console.WriteLine("Тhe enemy has no damage recorded."); }
        }

    }
}
