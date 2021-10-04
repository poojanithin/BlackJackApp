using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public class Dealer : Participants
    {
        public bool firstCardFlipped;

        public Dealer()
        {
            Name = "Dealer";
            firstCardFlipped = false;
        }

        // Returns the house name plus their hand and total score.
        public override void SetHandAsString()
        {
            HandAsString = Name + ": ";

            if (firstCardFlipped == false)
            {

                HandAsString += "XX ";

                for (int i = 1; i < Hand.Count; i++)
                {
                    HandAsString += Hand[i].ToString() + " ";
                }

            }

            else
            {

                foreach (Card card in Hand)
                {
                    HandAsString += card.ToString() + " ";
                }

                HandAsString += " Total: " + HandTotal.ToString();

                if (HandTotal > 21)
                {
                    HandAsString += "  Bust!";
                }

            }
        }

    }
}