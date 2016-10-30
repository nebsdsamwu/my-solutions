using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07
{
    public class Hand <T> where T : Card
    {
        protected List<T> cards = new List<T>();
        public int CountScore()
        {
            int score = 0;
            foreach (Card c in cards)
            {
                score += c.FaceValue;
            }
            return score;
        }

        public void AddCard(T card)
        {
            cards.Add(card);
        }
    }
}
