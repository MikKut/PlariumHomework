using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace MainProject
{
    public abstract class Person : IComparable<Person>
    {
        [NonSerialized]
        object lockObj = new object();
        [NonSerialized]
        private DateTime _dateOfBirth;
        [NonSerialized]
        private string _name;
        [JsonPropertyName("category")]
        public abstract string Category { get; }
        [JsonPropertyName("name")]
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
        [JsonPropertyName("dateOfBirth")]
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
            try
            {
                Name = name;
                DateOfBirth = SetDateOfBirth(date, name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong inout data: \"{ex.Message}\", try again");
                SetStartData();
            }
        }
        public Person(string name, DateTime date)
        {
            try
            {
                Name = name;
                DateOfBirth = date;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong inout data: \"{ex.Message}\", try again");
                SetStartData();
            }
        }
        public Person()
        {
            
        }
        public Person(bool enterViaConsole)
        {
            if (enterViaConsole)
            {
                try
                {
                    SetStartData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wrong inout data: \"{ex.Message}\", try again");
                    SetStartData();
                }
            }
        }
        public int CompareTo(Person other)
        {
            lock (lockObj)
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
        public override string ToString()
        {
            return $"{this.Name} {this.DateOfBirth.ToString()}\n";
        }
        private void SetStartData()
        {
            lock (lockObj)
            {

                Console.WriteLine("Enter his/her name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter his/her date of birth: ");
                DateOfBirth = SetDateOfBirth(Console.ReadLine(), Name);
            }
        }
        private static DateTime SetDateOfBirth(string date, string name)
        {
            if (!DateTime.TryParse(date, out DateTime temp))
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
