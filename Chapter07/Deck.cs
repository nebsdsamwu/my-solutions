using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07
{
    public class Deck<T> where T : Card
    {
        private List<T> cards;
        private int dealtIndex = 0;

        public List<T> Cards 
        {
            get {return cards;}
            set { cards = value; }
        }

        public int DealtIndex
        {
            get { return dealtIndex; }
            set { dealtIndex = value; }
        }

    }
}
