using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerArmy F = new ComputerArmy(1000);
            ComputerArmy S = new ComputerArmy(1000);
            F.CreateArmy();
            S.CreateArmy();
            Engine E = Engine.getInstance(F, S);

            while (E.NextTurn())
            {

            }
        }
    }
}
