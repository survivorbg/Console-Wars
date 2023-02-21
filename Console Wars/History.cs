namespace RPG_Game
{
    public class History
    {
        /// <summary>
        /// This list will collect all the players actions during the game.
        /// </summary>
        public List<string> playerActions = new List<string>();
        public  int Attacks { get; protected set; } = 0;
        public  int Defends { get; protected set; } = 0;
        public  int Heals { get; protected set; } = 0;

        //TODO write definitions of the methods

        public void CollectPlayerActionsForHistory(string action)
        {
            var actionType = "";
            switch (action)
            {
                case "1":
                    actionType = "Single Attack";
                    this.Attacks++;
                    break;
                case "2":
                    actionType = "Defend";
                    this.Defends++;
                    break;
                case "3":
                    actionType = "Heal";
                    this.Heals++;
                    break;
                case "kill":
                    actionType = "CHEATING!!!!!";
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
            Console.WriteLine($"TOTAL: A{Attacks} D{Defends} H{Heals}");
        }


    }
}
