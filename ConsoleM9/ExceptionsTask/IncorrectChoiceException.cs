using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleM9
{
    internal class IncorrectChoiceException : Exception
    {
        public IncorrectChoiceException() { }
        public IncorrectChoiceException(string message):base(message)
        {

        }
    }
}
