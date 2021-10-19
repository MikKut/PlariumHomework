using System;

namespace VariantC
{
    class Director:Person
    {
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
