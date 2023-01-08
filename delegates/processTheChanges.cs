using System;
namespace homework2.delegates
{
    public class processTheChanges
    {
        public delegate void personHandler(List<Person> pepole);

        public void ProcessWithDelegate( personHandler personHandler, List<Person> pepole)
        {
            personHandler(pepole);
        }

    }
    
	
}

