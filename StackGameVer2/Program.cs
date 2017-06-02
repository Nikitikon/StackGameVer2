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
            UserArmy u = new UserArmy(100);
            u.AddUnit("Armor");
            u.AddUnit("Infantry");
            u.AddUnit("Armor");
            IAbility a = u.UnitList[1] as IAbility;


            while (true)
            {
                a.DoAbility(u.UnitList, null, 1);
            }

            //ComputerArmy F = new ComputerArmy(1000);
            //ComputerArmy S = new ComputerArmy(1000);
            //F.CreateArmy();
            //S.CreateArmy();
            //Engine E = Engine.getInstance(F, S);
            //while (E.NextTurn())
            //{
                
            //}
        }
    }
}
