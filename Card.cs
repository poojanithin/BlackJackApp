using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public class Card
    {

        public MyEnums.Rank Rank { get; private set; }

        public MyEnums.Suite Suite { get; private set; }


        public Card(MyEnums.Rank rank, MyEnums.Suite suite)
        {
        
            this.Suite = suite;
            this.Rank = rank;

        }




        private string name;



        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override string ToString()
        {
            char suite = '?';

            switch (this.Suite)
            {
                case MyEnums.Suite.C:
                    suite = '♣';
                    break;
                case MyEnums.Suite.D:
                    suite = '♦';
                    break;
                case MyEnums.Suite.H:
                    suite = '♥';
                    break;
                case MyEnums.Suite.S:
                    suite = '♠';
                    break;
            }

            var num = (int)this.Rank > 1 && (int)this.Rank < 11 ?
                ((int)this.Rank).ToString() :
                Enum.GetName(typeof(MyEnums.Rank), this.Rank).Substring(0, 1);

            return num + suite;
        }
    }
}