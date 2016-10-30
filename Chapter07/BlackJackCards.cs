using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07
{
    public class BlackJackCards : Card
    {
        public BlackJackCards(int v, Suit s) : base(v, s) { }
        
        public int GetValue()
        {
            if (IsAce())
            {
                return 1;
            }
            else if (FaceValue >= 11 && FaceValue <= 13)
            {
                return 10;
            }
            else return FaceValue;
        }

        public int MinValue()
        {
            if (IsAce())
            {
                return 1;
            }
            else
            {
                return GetValue();
            }
        }

        public int MaxValue()
        {
            if (IsAce())
            {
                return 11;
            }
            else
            {
                return GetValue();
            }
        }

        public bool IsAce()
        {
            return FaceValue == 1;
        }

        public bool IsFaceCard()
        {
            return FaceValue >= 11 && FaceValue <= 13;
        }
    }
}
