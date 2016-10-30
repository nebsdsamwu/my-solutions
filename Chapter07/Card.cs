using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07
{
    public abstract class Card
    {
        private bool available { get; set; }
        protected int faceValue { get; set; }
        protected Suit suit { get; set; }
        
        public Card(int v, Suit s)
        {
            faceValue = v;
            suit = s;  
        }

        //public abstract int FaceValue();

        public Suit Suit 
        { 
            get { return suit; }
            set { suit = value; }
        }
        public int FaceValue
        {
            get { return faceValue; }
            set { faceValue = value; }
        }

        public bool IsAvailable() { return available; }
        public void MarkUnavilable() { available = false; }
        public void MarkAvailable() { available = true; }
    }

    public enum Suit
    {
        Club = 0,
        Diamond = 1,
        Heart = 2,
        Spade = 3
    }
}
