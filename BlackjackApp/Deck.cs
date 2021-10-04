using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public class Deck
    {
        private List<Card> cardDeck = new List<Card>();

        public List<Card> CardDeck { get => cardDeck; set => cardDeck = value; }

        // Creates the playing deck.
        public List<Card> BuildCardDeck()
        {
            Deck deck = new Deck();

            foreach (MyEnums.Suite suite in Enum.GetValues(typeof(MyEnums.Suite)))
            {
                foreach (MyEnums.Rank rank in Enum.GetValues(typeof(MyEnums.Rank)))
                {
                    Card card = new Card(rank,suite);
                    

                    // Set card name.
                    if ((int)rank <= 10)
                    {
                        int temp = (int)rank;
                        card.Name = temp.ToString();
                    }
                    else
                    {
                        card.Name = rank.ToString();
                    }


                    deck.CardDeck.Add(card);
                }
            }

            return deck.CardDeck;
        }

        // Shuffles the playing deck.
        public List<Card> ShuffleDeck(List<Card> cardDeck)
        {
            var shuffledDeck = cardDeck.OrderBy(x => Guid.NewGuid()).ToList();

            return shuffledDeck;
        }
    }
} 