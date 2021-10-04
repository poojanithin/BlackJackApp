using System;
using BlackjackApp;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DeckTests
    {
        private Deck _deck;
        private Deck _shuffledDeck;

        [SetUp]
        public void SetUp()
        {
            _deck = new Deck();
            _deck.CardDeck = _deck.BuildCardDeck();
            _shuffledDeck = new Deck();
        }

        [Test]
        public void BuildCardDeckSuccessTest()
        {
            Assert.IsNotNull(_deck.CardDeck);
            Assert.AreEqual(52, _deck.CardDeck.Count);
            Assert.AreEqual(52, _deck.CardDeck.Distinct().Count());
            Assert.AreEqual(52, _deck.CardDeck.Select(c => c.ToString()).Distinct().Count());
           
        }

        [Test]
        public void ShuffleDeckSuccessTest()
        {
            
            var position = 0;
            var newPosition = 0;
            var deck = new Deck();
            var positions = _deck.CardDeck.ToDictionary(c => c, c => position++);


            _shuffledDeck.CardDeck = _deck.ShuffleDeck(_deck.CardDeck);

            foreach (var card in _shuffledDeck.CardDeck)
            {
                Console.WriteLine(card);
            }

            var positionChangeCount = _shuffledDeck.CardDeck.Select(c => positions[c] == newPosition++ ? 0 : 1).Sum();

            // Assert
            Assert.IsTrue(positionChangeCount > 52 * .9);
            Assert.AreEqual(52, _shuffledDeck.CardDeck.Count);
            Assert.AreEqual(52, _shuffledDeck.CardDeck.Distinct().Count());
            Assert.AreEqual(52, _shuffledDeck.CardDeck.Select(c => c.ToString()).Distinct().Count());
         
        }

    }
}
