using System;

namespace MainProject
{
    public class Actor : Person
    {
        string _category = "actor";
        public override string Category { get =>_category; }
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
