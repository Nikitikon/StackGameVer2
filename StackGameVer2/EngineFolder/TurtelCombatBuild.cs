using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class TurtelCombatBuild : CombatBuild
    {
        public override string FightStategy(List<IUnit> UserArmy, List<IUnit> ComputerArmy)
        {
            int Count = 3;
            if (UserArmy.Count < Count)
                Count = UserArmy.Count;
            if (ComputerArmy.Count < Count)
                Count = ComputerArmy.Count;

            string result = "";

            for (int i = 0; i < Count; i++)
            {
                result += FightUnit(UserArmy[i], ComputerArmy[i]);
            }

            return result;
        }
    }
}
