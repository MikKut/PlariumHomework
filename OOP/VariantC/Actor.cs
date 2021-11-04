using System;

namespace VariantC
{
    public class Actor : Person, IComparable<Person>
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
