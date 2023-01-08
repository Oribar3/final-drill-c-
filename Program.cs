using homework2.delegates;
using homework2;
using static homework2.delegates.processTheChanges;
using System.Collections.Generic;

namespace homework
{
    class program
    {
        static void Main(string[] args)
        {
            DataList dataList = new()
            {
                people = new()
            };
            bool end = false;
            processTheChanges processTheChanges = new();
            addRemoveSearch changingAmountOfPersons = new();
            processTheChanges.personHandler changingAmountOrSearch =
                changingAmountOfPersons.addPerson;

            Console.WriteLine(" welcome to your data base! \n");
            do
            {
                string clientRequest = dataList.DataListRequest();
                switch (clientRequest)
                {
                    case "1":
                        changingAmountOrSearch = changingAmountOfPersons.addPerson;
                        processTheChanges.ProcessWithDelegate(changingAmountOrSearch, dataList.people);
                        break;
                    case "2":
                        if (dataList.isTheListIsEmpty() == true)
                            break;
                        changingAmountOrSearch = changingAmountOfPersons.removePerson;
                        processTheChanges.ProcessWithDelegate(changingAmountOrSearch, dataList.people);
                        break;
                    case "3":
                        if (dataList.isTheListIsEmpty() == true)
                            break;
                        changingAmountOrSearch = changingAmountOfPersons.search;
                        processTheChanges.ProcessWithDelegate(changingAmountOrSearch, dataList.people);
                        break;
                    case "4":
                        if (dataList.isTheListIsEmpty() == true)
                            break;
                        dataList.printDateList();
                        break;
                    case "5":
                        end = true;
                        break;
                    default:
                        Console.WriteLine("your input is invaild");
                        break;

                }
            }
            while (end==false);
        }
    }

 
}