using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab44
{
    public class InputOutput
    {
        public void PrintString(string s)
        { 
            Console.WriteLine(s); 
        }
        public void PrintArray(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
                Console.WriteLine(s[i]);
        }
        public string ReadString()
        { 
            return Console.ReadLine(); 
        }
        public DateTime GetValidDate()
        {
            while (true)
            {
                string incomingDate = Console.ReadLine();
                if (!string.IsNullOrEmpty(incomingDate) && !string.IsNullOrWhiteSpace(incomingDate))
                {
                    try
                    {
                        var parsedDate = DateTime.Parse(incomingDate);
                        var formattedDate = parsedDate.ToString("dd.MM.yyyy");

                        if (incomingDate.Equals(formattedDate))
                        {
                            return parsedDate;
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка ввода! Дата введена неверно");
                    }
                }
            }
        }

        public int GetValidInt()
        {
            do
            {
                int res;
                string EnteredValue = Console.ReadLine();
                bool check = int.TryParse(EnteredValue, out res);
                if (check == true)
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Error! Try again.\r");
                }
            } while (true);
        }

    }
}
