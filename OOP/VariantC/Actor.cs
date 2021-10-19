using System;

namespace VariantC
{
    public class Actor : Person
    {
        public Actor(string name, string date) : base(name, date)
        {
           
        }
        public Actor(string name, DateTime date) : base(name, date)
        {

        }
        public Actor() : base()
        { 
            
        }
    }
}
