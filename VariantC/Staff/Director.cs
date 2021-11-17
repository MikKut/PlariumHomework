using System;

namespace MainProject
{
    [Serializable]
    class Director:Person
    {
        private readonly string _category = "director";
        public override string Category { get => _category; }
        public Director(string name, string date) : base(name, date)
        {

        }
        public Director(string name, DateTime date) : base(name, date)
        {

        }
        public Director(bool enterViaConsole) : base(enterViaConsole)
        {
            
        }
        public Director() : base()
        {
        }
       

    }
}
