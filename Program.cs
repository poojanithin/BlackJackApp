using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerGroup playerGroup = new PlayerGroup();
            Game game = new Game();
            Dealer dealer = new Dealer();
            bool gameOver = false;
            bool keepPlaying = true;
            int numberOfPlayers;
            string userInput = "";

            Console.WriteLine("Welcome to Blackjack!" + "\r\n\r\n\r\n");

            // Get number of players.
            numberOfPlayers = playerGroup.SetNumberOfPlayers();

            // Set players names.
            playerGroup.SetPlayersNames(numberOfPlayers);

            while (keepPlaying == true)
            {
                while (gameOver == false)
                {
                    // Create and shuffle deck.
                    Deck deck = new Deck();
                    deck.CardDeck = deck.BuildCardDeck();
                    deck.CardDeck = deck.ShuffleDeck(deck.CardDeck);

                    game.Deal(deck, playerGroup, dealer);
                    dealer.HandTotal = dealer.CountCards();
                    dealer.SetHandAsString();

                    // Print the dealer's hand.
                    Console.WriteLine("\r\n\r\n" + dealer.HandAsString);

                    Console.Write("\r\n\r\n" + "Press enter to deal hands...");
                    Console.ReadLine();

                    // Deal first round of cards.            
                    // Print each of the players hands.
                    foreach (Player player in playerGroup.PlayerList)
                    {
                        player.HandTotal = player.CountCards();
                        player.SetHandAsString();

                        Console.WriteLine("\r\n" + player.HandAsString);
                    }

                    Console.WriteLine();
               

                    gameOver = game.CheckBlackJack(playerGroup,dealer);



                    // If someone hasnt got blackjack then continue - necessary as not exiting while loop
                    if (gameOver == false)
                    {
                        // Loop through the list of players.
                        foreach (Player player in playerGroup.PlayerList)
                        {
                            // Count current players hand.
                            player.HandTotal = player.CountCards();
                            player.SetHandAsString();

                            // If player hasnt bust.
                            if (player.Bust == false)
                            {
                                Console.WriteLine("\r\n" + player.HandAsString);

                                string playerHit = "Y";

                                // Loop while player hasnt won, bust or stayed.
                                while (playerHit != "N" && gameOver == false && player.Bust == false)
                                {
                                    Console.Write("Would you like another card (y/n)? ");
                                    playerHit = Console.ReadLine().ToUpper();

                                    // Validation for user input.
                                    while (playerHit != "Y" && playerHit != "N")
                                    {
                                        Console.WriteLine("Incorrect input...");
                                        Console.Write("\r\n" + "Would you like another card(y/n)?: ");
                                        playerHit = Console.ReadLine().ToUpper();
                                    }

                                    // If player selects hit, deal them a card and remove it from the deck.
                                    if (playerHit == "Y")
                                    {
                                        game.Hit(player, deck);
                                        player.HandTotal = player.CountCards();
                                        player.SetHandAsString();

                                        Console.WriteLine("\r\n" + player.HandAsString);


                                    }
                                }
                            }
                        }

                        // 'Flip' the dealer's first card. 
                        dealer.firstCardFlipped = true;
                        dealer.SetHandAsString();
                        Console.WriteLine("\r\n" + dealer.HandAsString);

                        // Determine the highest score
                        playerGroup.GetHighestHand(playerGroup);

                        if (dealer.HandTotal > playerGroup.HighestHand)
                        {                         
                            Console.WriteLine("\r\n" + dealer.Name + " Wins!");
                            gameOver = true;
                        }
                        else
                        {
                            // Loop and keep hiting dealer hand if it hasnt won, bust or gone over 17.
                            while (gameOver == false && dealer.HandTotal <= 16 && dealer.HandTotal < playerGroup.HighestHand)
                            {
                          
                                Console.WriteLine("\r\n" + "Press enter to deal the House a card...");
                                Console.ReadLine();

                                game.Hit(dealer, deck);
                                dealer.HandTotal = dealer.CountCards();
                                dealer.SetHandAsString();

                                Console.WriteLine("\r\n" + dealer.HandAsString);
                            }

                            // If house has bust all players who havent, win.
                            if (dealer.Bust == true)
                            {
                                foreach (Player player in playerGroup.PlayerList)
                                {
                                    if (player.Bust == false)
                                    {
                                        Console.WriteLine("\r\n" + player.Name + " Wins!");
                                    }
                                }

                                gameOver = true;
                            }
                            // Else dealer must have 17-21 so check and display win/draw
                            else
                            {
                                if (dealer.HandTotal > playerGroup.HighestHand)
                                {
                                    Console.WriteLine("\r\n" + dealer.Name + " Wins!");
                                    gameOver = true;
                                }
                                else if (dealer.HandTotal < playerGroup.HighestHand)
                                {
                                    foreach (Player player in playerGroup.PlayerList)
                                    {
                                        if (player.HandTotal > dealer.HandTotal && player.Bust == false)
                                        {
                                            Console.WriteLine("\r\n" + player.Name + " Wins!");
                                        }
                                    }

                                    gameOver = true;
                                }
                                else
                                {
                                    Console.WriteLine("\r\n" + dealer.Name + " Tie...");

                                    foreach (Player player in playerGroup.PlayerList)
                                    {
                                        if (player.HandTotal == dealer.HandTotal)
                                        {
                                            Console.WriteLine("\r\n" + player.Name + " Tie...");
                                        }
                                    }

                                    gameOver = true;
                                }
                            }
                        }
                    }

                    Console.Write("\r\n\r\n" + "Game over! Play again (y/n)? ");
                    userInput = Console.ReadLine().ToUpper();

                    // Validate user input.
                    while (userInput != "Y" && userInput != "N")
                    {
                        Console.Write("Incorrect input...");
                        Console.Write("\r\n\r\n" + "Play again (y/n)? ");
                        userInput = Console.ReadLine().ToUpper();
                    }

                    if (userInput == "N")
                    {
                        keepPlaying = false;
                    }
                    else
                    {
                        dealer.ResetHand();

                        foreach (Player player in playerGroup.PlayerList)
                        {
                            player.ResetHand();
                        }

                        playerGroup.ResetPlayerGroup();

                        keepPlaying = true;
                        gameOver = false;
                        dealer.firstCardFlipped = false;
                    }
                }
            }
        }
    }
}