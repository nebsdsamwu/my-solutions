using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07CallCenter
{
    public abstract class Employee
    {
        private string name;
        private int id;
        private string position;
        private bool available;

        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
    }

    protected enum Position
    {
        Respodent = 0,
        Manager = 1,
        Director = 2
    }
}
