using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
     public class Player : Participants
    {
        // Returns the players name plus their hand and total score.
        public override void SetHandAsString()
        {
            HandAsString = Name + ": ";

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