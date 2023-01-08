using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace homework2.delegates
{
	public class addRemoveSearch
	{

        public bool isVaildNumberInput(string input)
        {
            bool vaild = true;
                vaild = true;
                try
                {
                    int.Parse(input);
                }
                catch (Exception)
                {
                    vaild = false;
                    Console.WriteLine("your input is invaild");
                };
            return vaild;
        }
        public bool isYesOrNoInput(string input)
        {
            if (input == "yes" || input == "no")
                return true;
            else
                Console.WriteLine("your input is invaild");
                return false;
        }
        public void search(List<Person> pepole)
        {
           
            Search search = new();
            Console.WriteLine($"according to which property would " +
                $"you like to make a search?\n1.name\n2.age\n3.hobby\n" +
                $"4.characteristic");
            string choise = Console.ReadLine();
            List<Person> searchResult = new();
            switch (choise)
            {
                case "1":
                    Console.WriteLine("what is the name you want to search " +
                        "for?");
                    string name = Console.ReadLine();
                    searchResult = search.
                        FindAllName(pepole, name);
                    search.printSearchResults(searchResult);
                    break;
                case "2":
                    Console.WriteLine("what is the age you want to search " +
                       "for?");
                    string age = Console.ReadLine();
                    searchResult = search.FindAllAge
                        (pepole, int.Parse(age));
                    search.printSearchResults(
                        searchResult);
                    break;
                case "3":
                    Console.WriteLine("what is the hobby you want to search " +
                      "for?");
                    string hobby= Console.ReadLine();
                    searchResult=
                        search.FindAllHobbies(pepole, hobby);
                    search.printSearchResults(searchResult);
                    break;
                case "4":
                    Console.WriteLine("what is the characteristic you want to search " +
                    "for?");
                    string characteristic = Console.ReadLine();
                    searchResult =
                        search.FindAllcharacteristics(pepole, characteristic);
                    search.printSearchResults(searchResult);
                    break;

            }

        }
        public void removePerson(List<Person> pepole)
        {
          
            Console.WriteLine("what is the name of the person you want to remove?");
            string name = Console.ReadLine();

            Search search = new();
            List<Person> searchResult = search.FindAllName(pepole, name);
            if (searchResult.Count == 0)
            {
                Console.WriteLine($"you dont have {name} in your list");
                return;
            }
            Person personToRemove;
            
            if (searchResult.Count > 1)
            {
                Console.WriteLine($"you have {searchResult.Count} pepole answering that name. what is the id of the person you want to remove?");
                do
                {
                    string id = Console.ReadLine();
                    personToRemove = searchResult.Find(person => person.Id == id);
                    if (personToRemove == null)
                        Console.WriteLine("you had a mistake in their id,try again");
                }
                while (personToRemove == null);
            }
            else
                personToRemove = searchResult.First();

          
            if (pepole.Contains(personToRemove))
            {
                pepole.Remove(personToRemove);
                Console.WriteLine($"{personToRemove.Name} removed succssefully");
            }
            else
                Console.WriteLine($"{personToRemove.Name} is not removed succssefully");
        }
     
        public void addPerson(List<Person> pepole)
        {

            Person person = new();
            bool vaild;
            string input;
            Console.WriteLine("name:");
            person.Name = Console.ReadLine();

            do
            {
                Console.WriteLine("age:");
                input = Console.ReadLine();
                vaild = isVaildNumberInput(input);
                if (vaild)
                    person.Age = int.Parse(input);
            }
            while (vaild == false);

            Console.WriteLine("id:");
            person.Id = Console.ReadLine();
            
            bool gotHobbies = true;
            do
            {
                Console.WriteLine("do you want to add hobbies? yes/no");
                input = Console.ReadLine();
                vaild = isYesOrNoInput(input);
                if (vaild)
                {
                    if (input == "yes")
                        gotHobbies = true;
                    else
                        gotHobbies = false;
                }
               
            }
            while (vaild == false);

            if (gotHobbies)
            {
                person.hobbies = new();
                do
                {
                    Console.WriteLine($"how many hobbies {person.Name} has?");
                    input = Console.ReadLine();
                    vaild= isVaildNumberInput(input);
                    if (vaild)
                    {
                        int numberOfHobbies = int.Parse(input);
                        for (int i = 0; i < numberOfHobbies; i++)
                        {
                            Console.WriteLine("enter your hobby name:");
                            string nameOfHobby = Console.ReadLine();
                            int minutesInvestedPerDay = 0;
                            do
                            {
                                Console.WriteLine("how much minutes are you investing on that hobby a day?");
                                input = Console.ReadLine();
                                vaild = isVaildNumberInput(input);
                                if (vaild)
                                {
                                     minutesInvestedPerDay = int.Parse(input);
                                }
                            }
                            while (!vaild);

                            person.hobbies.Add(new Hobby() { HobbyName = nameOfHobby, MinutesInvestedADay = minutesInvestedPerDay });
                        }
                    }
                }
                while (vaild == false);
            }
            bool gotCharacteristics = true;
            do
            {
                Console.WriteLine("do you want to add characteristics? yes/no");
                input = Console.ReadLine();
                vaild = isYesOrNoInput(input);
                if (vaild)
                {
                    if (input == "yes")
                        gotCharacteristics = true;
                    else
                        gotCharacteristics = false;
                }

            }
            while (vaild == false);

            if (gotCharacteristics)
            {
                person.characteristics = new();
                do
                {
                    Console.WriteLine($"how many characteristics {person.Name} has?");
                    input = Console.ReadLine();
                    vaild = isVaildNumberInput(input);
                    if (vaild)
                    {
                        int numberOfcharacteristics = int.Parse(Console.ReadLine());
                        for (int i = 0; i < numberOfcharacteristics; i++)
                        {
                            Console.WriteLine("enter your characteristic name:");
                            string nameOfcharacteristic = Console.ReadLine();
                            person.characteristics.Add(new Characteristic() { CharacteristicName = nameOfcharacteristic });
                        }
                    }
                }
                while (!vaild);
            }
            pepole.Add(person);

            Console.WriteLine($"{person.Name} added succssefully");
        }
    }
}

