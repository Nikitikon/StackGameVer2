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
            string U = string.Empty;

            while (!U.Equals("e"))
            {
                Console.WriteLine("Введи: ");
                U = Console.ReadLine();
                Console.WriteLine(E.NextTurn());
            }
        }
    }
}
