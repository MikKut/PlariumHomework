using System;

namespace MainProject
{
    class Director:Person
    {
        string _category = "director";
        public override string Category { get => _category; }
        public Director(string name, string date) : base(name, date)
        {

        }
        public Director(string name, DateTime date) : base(name, date)
        {

        }
        public Director() : base()
        {
        }
       

    }
}
