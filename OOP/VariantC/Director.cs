using System;

namespace VariantC
{
    class Director:Person, IComparable<Person>
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
        public int CompareTo(Person other)
        {
            int date = this.DateOfBirth.CompareTo(other.DateOfBirth), name = this.Name.CompareTo(other.Name);
            if (name == 0)
            {
                if (date == 0)
                {
                    return 0;
                }
                else
                {
                    if (date > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (name > 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

    }
}
