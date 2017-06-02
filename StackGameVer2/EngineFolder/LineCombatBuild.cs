using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class LineCombatBuild : CombatBuild
    {

        public override string FightStategy(List<IUnit> UserArmy, List<IUnit> ComputerArmy)
        {
            return FightUnit(UserArmy[0], ComputerArmy[0]);
        }
    }
}
