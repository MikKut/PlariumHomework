using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class RussianRoulette
    {
        private int quantityOfPersons = 0;
        Lazy<ArrayList> ar = null;
        Lazy<LinkedList<Person>> ls = null;
        public RussianRoulette(ArrayList the_collection)
        {
            if (the_collection.Count > 0)
            {
                ar = new Lazy<ArrayList>(the_collection);
            }
            else 
            {
                throw new ArgumentException("Null size of the collection");
            }
        }
        public RussianRoulette(LinkedList<Person> the_collection)
        {
            if (the_collection.Count > 0)
            {
                ls = new Lazy<LinkedList<Person>>(the_collection);
            }
            else
            {
                throw new ArgumentException("Null size of the collection");
            }
        }
        public void PlayRussianRoulette()
        {
            try
            {
                if (ar != null)
                {
                    Console.WriteLine(PlayRussianRouletteViaArrayList().Name);
                }
                else
                {
                    if (ls != null)
                    {
                        Console.WriteLine(PlayRussianRouletteLinkedList().Name);
                    }
                    else
                    {
                        throw new ArgumentException("The collection is not ArrayList or LinkedList<Person>");
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private Person PlayRussianRouletteViaArrayList()
        {
            try
            {
                var leftPersons = new ArrayList(ar.Value);
                int i = 1, j = 0, count = leftPersons.Count, numberOfFallen = i;
                bool isEven = count % 2 == 0;
                while (count > 1)
                {
                    if (!isEven)
                    {
                        if (count == 2)
                        {
                            return numberOfFallen % 2 == 1  ? (Person)leftPersons[0] : (Person)leftPersons[1];
                        }
                        if (count == 3)
                        {
                            if (numberOfFallen < count)
                            {
                                leftPersons.RemoveAt(numberOfFallen);
                            }
                            else
                            {
                                leftPersons.RemoveAt(i);
                            }
                            if (i == 0)
                            {
                                return (Person)leftPersons[0];
                            }
                            else
                            {
                                return (Person)leftPersons[1];
                            }
                        }
                    }
                    for (j = 0; j < count / 2; j++)
                    {
                        leftPersons.RemoveAt(i);
                        i++;
                    } 
                    numberOfFallen = i;
                    i = count % 2 == 1 ? 0 : 1;
                    count = leftPersons.Count;
                }
                return (Person)leftPersons[0];
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException($"Cannot cast an element of ArrayList to Person during executing PlayRussianRouletteViaArrayList method: \"{ex.Message}\"");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        private Person PlayRussianRouletteLinkedList()
        {
                LinkedListNode<Person> node1, node2 = ls.Value.Last;
                LinkedList<Person> leftPersons = new(ls.Value);
                while (leftPersons.Count != 1)
                {
                    node1 = leftPersons.First;
                    node2 = leftPersons.Last;
                    while (node2 != null)
                    {
                        node2 = node1.Next;
                        if (node2 != null)
                        {
                            if (node2.Next == null)
                            {
                                leftPersons.Remove(node2);
                                break;
                            }
                            node2 = node2.Next;
                            leftPersons.Remove(node2.Previous);
                            node1 = node2;
                        }
                        else
                        {
                            leftPersons.RemoveFirst();
                            break;
                        }

                    }
                }

                return leftPersons.First.Value;
        }
    }
}
