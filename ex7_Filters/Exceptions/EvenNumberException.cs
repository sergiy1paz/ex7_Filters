using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex7_Filters.Exceptions
{
    public class EvenIntNumberException : Exception
    {
        public EvenIntNumberException() { }

        public EvenIntNumberException(string message) : base(message){ }
        
        public static void CheckNumber(int number)
        {
            if (number % 2 == 0)
            {
                throw new EvenIntNumberException($"This number is even!!! Number = {number}");
            }
        } 
    }
}
