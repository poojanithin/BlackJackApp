using System;
using BlackjackApp;
using NUnit.Framework;

namespace Tests
{
        [TestFixture]
        public class GameTests
        {
            private Game _game;

            [SetUp]
            public void SetUp()
            {
                _game = new Game();
            }

            [Test]
            public void CheckBlackJack_IsTrue_Test()
            {
                Player player = new Player();
                player.Name = "Pooja";
                PlayerGroup playerGroup = new PlayerGroup();
                Deck deck = new Deck();
                deck.CardDeck = deck.BuildCardDeck();
                player.Hand.Add(deck.CardDeck[11]);
                player.Hand.Add(deck.CardDeck[12]);
                player.HandTotal = player.CountCards();
                
                playerGroup.PlayerList.Add(player);
                Dealer house = new Dealer();
                house.Hand.Add(deck.CardDeck[9]);
                house.Hand.Add(deck.CardDeck[12]);
                house.HandTotal = house.CountCards();

                Assert.IsTrue(_game.CheckBlackJack(playerGroup, house));
            }

            [Test]
            public void CheckBlackJack_IsFalse_Test()
            {
                Player player = new Player();
                player.Name = "Pooja";
                PlayerGroup playerGroup = new PlayerGroup();
                Deck deck = new Deck();
                deck.CardDeck = deck.BuildCardDeck();
                player.Hand.Add(deck.CardDeck[11]);
                player.Hand.Add(deck.CardDeck[12]);
                player.HandTotal = player.CountCards();

                playerGroup.PlayerList.Add(player);
                Dealer house = new Dealer();
                house.Hand.Add(deck.CardDeck[10]);
                house.Hand.Add(deck.CardDeck[15]);
                house.HandTotal = house.CountCards();

                Assert.IsFalse(_game.CheckBlackJack(playerGroup, house));
            }
        }
}
