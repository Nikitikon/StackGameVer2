using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ComputerArmy : Army
    {
        
        public ComputerArmy(int Money) : base(Money)
        {
            
        }

        public override int CreateArmy()
        {
            if (UnitList == null)
            {
                UnitList = new List<IUnit>();
            }

            if (_ArmyCreater == null)
            {
                _ArmyCreater = new ArmyCreater();
            }

            ArmyAlgoritmCreater();

            return Money;
        }
    }
}
