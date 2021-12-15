using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab44
{



    public class Program
    {
       
        static Task Menu = new Task("Menu");
        static Case0 _0 = new Case0("[0] Close");
        static Case1 _1 = new Case1("[1] Hello World!");
        static Case2 _2 = new Case2("[2] Calc <x % z + sqrt(y)>");
        static Case3 _3 = new Case3("[3] Recursion date");
        static Case4 _4 = new Case4("[4] Strings");
        static void Main()
        {
                Menu.DoTask(_0, _1, _2, _3, _4);
        }
    }
}
