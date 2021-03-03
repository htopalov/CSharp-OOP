using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Dialing... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
