using System;

namespace VariantC
{
    public abstract class Person
    {
        private DateTime _dateOfBirth;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name of his/her is empty");
                }
                else 
                {
                    _name = value;
                }
            }
        }
        public DateTime DateOfBirth 
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception($"Date of birth of actor {Name} more than current time");
                }
                _dateOfBirth = value;
            }
        } 
        public Person(string name, string date)
        {
            Name = name;
            DateOfBirth = SetDateOfBirth(date, name);
        }
        public Person(string name, DateTime date)
        {
            Name = name;
            DateOfBirth = date;
        }
        public Person()
        {
            try
            {
                SetStartData();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Wrong inout data: \"{ex.Message}\", try again");
                SetStartData();
            }
        }
        private void SetStartData()
        {
            Console.WriteLine("Enter his/her name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter his/her date of birth: ");
            DateOfBirth = SetDateOfBirth(Console.ReadLine(),Name);
        }
        private DateTime SetDateOfBirth(string date, string name)
        {
            DateTime temp;
            if (!DateTime.TryParse(date, out temp))
            {
                throw new Exception($"Wrong birth date of {name}");
            }
            return temp;
        }
        public void ShowInformation()
        {
            Console.Write($"{Name} was born in {DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year}");
        }
        public bool Equal(Person person)
        {
            if (person.Name == this.Name && person.DateOfBirth == this.DateOfBirth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
