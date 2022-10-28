namespace RPG_Game
{
    public class History
    {
        /// <summary>
        /// This list will collect all the players actions during the game.
        /// </summary>
        public List<string> playerActions = new List<string>();
       
        //TODO write definitions of the methods
       
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
                case "kill":
                    actionType = "CHEATING!!!!!";
                    break;
                default:
                    actionType = "Invalid Action";
                    break;
            }
            playerActions.Add(actionType);
        }
        //public void CollectPlayerDamagesForHistory(int hit_value)
        //{
        //    playerDamages.Add(hit_value);
        //}

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


    }
}
