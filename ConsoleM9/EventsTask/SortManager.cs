using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleM9.EventsTask
{
    internal class SortManager
    {
        private string[] LastNames;

        public void RunManager()
        {
            CreateLastNames();
            SortTypeReader typeReader = new SortTypeReader();
            typeReader.TypeEnteredEvent += SortLastNames;
            bool isContinue = true;
            while(isContinue)
            {
                try
                {
                    typeReader.ReadType();
                    isContinue = false;
                }
                catch (IncorrectChoiceException exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }

        public void SortLastNames(int sortType)
        {
            PrintLastNames();
            string[] sortedArray = { };
            if (sortType == 1)
            {
                sortedArray = LastNames.OrderBy(x => x).ToArray();
            }
            if (sortType == 2)
            {
                sortedArray = LastNames.OrderByDescending(x => x).ToArray();
            }
            LastNames = sortedArray;
            PrintLastNames();
        }

        public void CreateLastNames()
        {
            LastNames = new string[5];
            LastNames[0] = "Петров";
            LastNames[1] = "Васечкин";
            LastNames[2] = "Иванов";
            LastNames[3] = "Аксенов";
            LastNames[4] = "Яшин";
        }

        public void PrintLastNames()
        {
            Console.WriteLine("\nИсходный список фамилий:");
            foreach (string lastName in LastNames)
            {
                Console.WriteLine(lastName);
            }
        }
    }
}
