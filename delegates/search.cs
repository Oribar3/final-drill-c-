using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace homework2.delegates
{
	public class Search
	{
        
        public List<Person> FindAllAge(List<Person>people, int value)
        {
            var searchResult = people.FindAll(person => person.Age == value);
     
            return searchResult;
        }
        public List<Person> FindAllName(List<Person> people, string value)
        {
            var searchResult = people.FindAll(person => person.Name == value);

            return searchResult;
        }
        public List<Person> FindAllHobbies(List<Person> people, string value)
        {
            try
            {
                var searchResult = people.FindAll(person => person.hobbies.Exists(hobby
                    => hobby.HobbyName == value));
                return searchResult;
            }
            catch (Exception)
            {
            }

            return null;

        }
        public List<Person> FindAllcharacteristics(List<Person> people, string value)
        { 
            try
            {
                var searchResult = people.FindAll(person => person.characteristics.Exists(characteristic
                => characteristic.CharacteristicName == value));

                return searchResult;
            }
            catch (Exception)
            {
            }

            return null;
        }
        public void printSearchResults(List<Person> SearchResult)
        {
            Console.WriteLine("the Search Result are:");
            if (SearchResult == null || SearchResult.Count == 0)
            {
                Console.WriteLine("there isn't a person on your list that answer your search");
                return;
            }
            foreach (Person person in SearchResult)
            {
                person.print();
            }
            
        }
    }
}

