using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{

    public class Game 
    {
        
        private Random random = new Random();
        private int randomCard;


        public bool CheckBlackJack( PlayerGroup playerGroup, Dealer dealer)
        {
            bool isBlackJack = false;

            foreach (Player player in playerGroup.PlayerList)
            {
                if (player.HandTotal == 21)
                {
                    playerGroup.WinningPlayers.Add(player);
                }
            }

            // If anyone has blackjack.
            if (playerGroup.WinningPlayers.Count > 0 || dealer.HandTotal == 21)
            {
                isBlackJack = true;

                // 'Flip' the dealer's first card. 
                dealer.firstCardFlipped = true;
                dealer.SetHandAsString();
                Console.WriteLine("\r\n" + dealer.HandAsString);

                // Blackjack for player/s and house.
                if (playerGroup.WinningPlayers.Count > 0 && dealer.HandTotal == 21)
                {
                    foreach (Player player in playerGroup.WinningPlayers)
                    {
                        Console.WriteLine("\r\n" + player.Name + " Tie...");
                    }                 
                    Console.WriteLine("\r\n" + dealer.Name + " Tie...");
                    
                }

                // Blackjack for house.
                if (playerGroup.WinningPlayers.Count == 0 && dealer.HandTotal == 21)
                {                   
                    Console.WriteLine("\r\n" + dealer.Name + " Wins - Blackjack");                 
                }

                // Blackjack for player/s.
                if (playerGroup.WinningPlayers.Count > 0 && dealer.HandTotal != 21)
                {
                    if (playerGroup.WinningPlayers.Count > 1)
                    {
                        foreach (Player player in playerGroup.WinningPlayers)
                        {
                            Console.WriteLine("\r\n" + player.Name + " Tie...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\r\n" + playerGroup.WinningPlayers[0].Name + " Wins - Blackjack!");
                    }

                    
                }
            }
            return isBlackJack;
        }

        // Deal first round of cards.
        public void Deal(Deck deck, PlayerGroup playerGroup, Dealer dealer)
        {
            // Give each player a card and remove card from deck.
            foreach (Player player in playerGroup.PlayerList)
            {
                Hit(player, deck);
            }

            // Give player second card. 
            foreach (Player player in playerGroup.PlayerList)
            {
                Hit(player, deck);
            }

            // Deal the house two cards.
            for (int i = 0; i < 2; i++)
            {
                Hit(dealer, deck);
            }
        }

        // Deal the player a random card from the deck.
        public void Hit(Participants participant, Deck deck)
        {
            randomCard = random.Next(deck.CardDeck.Count);

            participant.Hand.Add(deck.CardDeck[randomCard]);
            deck.CardDeck.Remove(deck.CardDeck[randomCard]);
       
        }
    }
}