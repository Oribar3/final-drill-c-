using System;
using homework2;
using System.Text;


namespace homework2.delegates
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public List<Hobby>? hobbies { get; set; }
        public List<Characteristic>? characteristics { get; set; }

        public void print()
        {
            Console.WriteLine($"{this.Name} is {this.Age} years old, id:{this.Id}. ");
           if(this.hobbies!=null)
            Console.WriteLine($"{this.printHobbies()}");
            if(this.characteristics!=null)
            Console.WriteLine($"{this.printCharacteristics()}");
            
        }

        public string printHobbies()
        {
            StringBuilder hobbies = new StringBuilder("hobbies list:\n");
            foreach (Hobby hobby in this.hobbies)
            {
                hobbies.Append (hobby.HobbyName);

                if (hobby.MinutesInvestedADay != null)
                    hobbies.Append($" get invested {hobby.MinutesInvestedADay} minutes a day\n");
                else
                    hobbies.Append( "\n");
            }
            return hobbies.ToString();
        }
        public string printCharacteristics()
        {
            StringBuilder Characteristics =new StringBuilder( "Characteristics list:\n");
            foreach (Characteristic Characteristic in this.characteristics)
            { 
                Characteristics.Append( Characteristic.CharacteristicName + "\n");

            }
            return Characteristics.ToString();
        }
        
    }
    

}

