using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07
{
    class BlackJackHand<T> where T : BlackJackCards
    {
        private List<int> GetPossibleScores() 
        {
            return new List<int>();
        }

        public int GetScore()
        {
            List<int> scores = GetPossibleScores();
            int MaxUnder = int.MinValue;
            int MinOver = int.MaxValue;

            foreach (int score in scores)
            {
                if (score > 21 && score < MinOver)
                {
                    MaxUnder = score;
                }
                else if(score <= 21 && score > MaxUnder)
                {
                    MaxUnder = score;
                }
            }

            return MaxUnder == int.MaxValue ? MinOver : MaxUnder;
        }

        public bool Busted()
        {
            return GetScore() > 21;
        }

        public bool Is21() { return GetScore() == 21; }

        public bool IsBlackJack()
        {
            return false;
        }
    }
}
