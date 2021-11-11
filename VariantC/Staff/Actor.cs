using System;

namespace MainProject
{
    [Serializable]
    public class Actor : Person
    {
        private readonly string _category = "actor";
        public override string Category { get =>_category; }
        public Actor(string name, string date) : base(name, date)
        {
           
        }
        public Actor(bool enterViaConsole) : base(enterViaConsole)
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
