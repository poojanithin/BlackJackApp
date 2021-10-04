using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
     public class PlayerGroup
    {
        private List<Player> playerList = new List<Player>();
        private List<Player> winningPlayers = new List<Player>();
        private int highestHand = 0;

        public List<Player> PlayerList { get => playerList; set => playerList = value; }
        public List<Player> WinningPlayers { get => winningPlayers; set => winningPlayers = value; }
        public int HighestHand { get => highestHand; set => highestHand = value; }

        // Reset for new round.
        public void ResetPlayerGroup()
        {
            WinningPlayers.Clear();
            highestHand = 0;
        }

        // Determine the highest score.
        public void GetHighestHand(PlayerGroup playerGroup)
        {
            int temp = 0;

            foreach (Player player in playerGroup.PlayerList)
            {
                temp = player.HandTotal;

                if (temp >= highestHand && player.HandTotal < 22)
                {
                    highestHand = temp;
                }
            }
        }

        // Sets the number of players.
        public int SetNumberOfPlayers()
        {
            int numberOfPlayers = 0;

            while (numberOfPlayers <= 0 || numberOfPlayers >= 3)
            {
                Console.Write("Please select the number of players (1-3): ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int value))
                {
                    numberOfPlayers = value;

                    if (numberOfPlayers <= 0 || numberOfPlayers >= 3)
                    {
                        Console.WriteLine("Incorrect input..." + "\r\n");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input..." + "\r\n");
                }
            }

            return numberOfPlayers;
        }

        // Set player/s names in player list.
        public void SetPlayersNames(int numberOfPlayers)
        {
            Console.WriteLine("\r\n");

            for (int i = 1; i < numberOfPlayers + 1; i++)
            {
                Console.Write("\r\n" + "Please enter player " + i + "'s name: ");
                string playersName = Console.ReadLine();

                while (playersName == "")
                {
                    Console.WriteLine("Players name cannot be empty...");
                    Console.Write("\r\n" + "Please enter player " + i + "'s name: ");
                    playersName = Console.ReadLine();
                }

                Player player = new Player();
                player.Name = "Player " + i + " - " + playersName;
                playerList.Add(player);
            }
        }
    }
}