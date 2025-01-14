using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleM9.EventsTask
{
    internal class SortTypeReader
    {
        public delegate void TypeEnteredDelegate(int sortType);
        public event TypeEnteredDelegate TypeEnteredEvent;

        public void ReadType()
        {
            Console.WriteLine();
            Console.WriteLine("Введите тип сортировки: 1 - по возрастанию, 2 - по убыванию");

            int sortType = Convert.ToInt32(Console.ReadLine());
            if (sortType != 1 && sortType != 2) throw new IncorrectChoiceException("Введен не корректный тип сортировки");
            TypeEntered(sortType);
        }

        protected virtual void TypeEntered(int sortType)
        {
            TypeEnteredEvent?.Invoke(sortType);
        }
    }
}
