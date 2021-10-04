using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public abstract class Participants
    {
        private List<Card> hand = new List<Card>();
        private string name;
        private int handTotal;
        private string handAsString;
        private bool bust = false;

        public string Name { get => name; set => name = value; }
        public int HandTotal { get => handTotal; set => handTotal = value; }
        public string HandAsString { get => handAsString; set => handAsString = value; }
        public List<Card> Hand { get => hand; set => hand = value; }
        public bool Bust { get => bust; set => bust = value; }

        public void ResetHand()
        {
            handTotal = 0;
            hand.Clear();
            bust = false;
        }

        // Count the cards in the dealers hand.
        public int CountCards()
        {
            HandTotal = 0;

            foreach (Card card in Hand)
            {
                
                HandTotal += (int)card.Rank;
                if ((int)card.Rank >= 12)
                {
                    HandTotal -= ((int)card.Rank - 10);
                }
                if (card.Name == "A" && HandTotal > 21)
                {
                    
                    HandTotal -= 10;
                }
            }

            if (HandTotal > 21)
            {
                Bust = true;
            }

            return HandTotal;
        }

        // Returns the players name plus their hand and total score.
        public virtual void SetHandAsString()
        {

        }
    }
}