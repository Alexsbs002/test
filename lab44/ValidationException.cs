using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab44
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { } 
                                                                       
        public static void OnException(ValidationException e)
        { 
            Console.WriteLine(e.Message);
        }
    }
}
