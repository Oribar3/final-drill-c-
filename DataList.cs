using System;
using homework2.delegates;

namespace homework2
{
	public class DataList
	{
		public string DataListRequest()
		{
			Console.WriteLine("choose youe action:\n1. Add person \n2. Delete person\n3.search\n4.Print the data base\n5.end the process");
			return Console.ReadLine();
		}
		public List<Person> people
		{
			get; set;
		}
		public void printDateList()
		{
			if (this.people.Count == 0)
			{
				Console.WriteLine("your DB list is empty");
				return;
			}

			for (int i = 0; i < this.people.Count; i++)
			{
				this.people[i].print();
			}
		}
        public bool isTheListIsEmpty()
        {
            if(this.people.Count == 0)
            {
                Console.WriteLine("your list is empty");
				return true;
            }
			return false;

        }
    }
}

