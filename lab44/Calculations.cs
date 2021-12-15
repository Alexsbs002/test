using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab44
{
    public class Calculations
    {
        public double Calc(int x, int y, int z) // case2
        {
            return Math.Round(x % z + Math.Sqrt(y), 3);
        }
        public int CalculateIntersectingDaysNumber(DateTime[,] EnteredValue) // case3
        {

            if ((EnteredValue[0, 0] <= EnteredValue[0, 1]) &&
            (EnteredValue[1, 0] <= EnteredValue[1, 1]) &&
            (EnteredValue[1, 0] >= EnteredValue[0, 1]))
            {
                return ((EnteredValue[1, 0] - EnteredValue[0, 1]).Days + 1);
            }
            if ((EnteredValue[0, 0] <= EnteredValue[0, 1]) &&
            (EnteredValue[1, 0] >= EnteredValue[1, 1]))
            {
                return ((EnteredValue[1, 1] - EnteredValue[0, 1]).Days + 1);
            }
            if ((EnteredValue[0, 0] >= EnteredValue[0, 1]) &&
            (EnteredValue[1, 0] >= EnteredValue[1, 1]))
            {
                return ((EnteredValue[1, 1] - EnteredValue[0, 0]).Days + 1);
            }
            if ((EnteredValue[0, 0] >= EnteredValue[0, 1]) &&
            (EnteredValue[1, 0] <= EnteredValue[1, 1]) &&
            (EnteredValue[1, 1] >= EnteredValue[0, 0]))
            {
                return ((EnteredValue[1, 1] - EnteredValue[0, 0]).Days + 1);
            }

            return 0;
        }
    }
}
