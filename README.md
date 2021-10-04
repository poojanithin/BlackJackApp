This is a simple version of the Blackjack game conforming to the rules mentioned in the assignment, developed as a console application using C# and Visual Studio and can be run on macOS.

Prerequisites:
Install .netcore 2.2 SDK
Add Nunit 3 and Microsoft.Net.Test SDK to the test project

Features:

1. BlackJack : also called Natural Win : When the dealer deals you an Ace and a Face Card with value 10.
2. Hit : When you want the dealer to deal you an additional card.
3. Stand: When you chose to Hit further, or not take any more cards.
4. Push/Tie: When the total value of the hands of the dealer and the player are same.
5. Bust: When the hand total of the dealer or the player exceeds the value 21. If both exceeds 21 in the first deal, the player always busts.

Run the game through command line:

1. Navigate to the project BlackjackApp
2. ’dotnet run’ to start the game


Unit tests scenarios:

1. Game class: CheckBlackJack() method to return true when there is a blackjack for either the player or the dealer, return false when there is no blackjack for either of them.
2. Deck class: BuildCardDeck() method to build the deck of 52 distinct cards.
3. Deck class: ShuffleDeck() method to shuffle the deck of 52 distinct cards, and to verify the position of the cards have moved by 1 position at the least.

Run the unit tests through command line

1. Navigate to the project BlackjackTests
2. ‘dotnet test’ to start the tests




