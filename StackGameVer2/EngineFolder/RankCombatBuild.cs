using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class RankBuild : CombatBuild
    {
        public override string FightStategy(List<IUnit> UserArmy, List<IUnit> ComputerArmy)
        {
            int FirstArmyCount = UserArmy.Count;
            int SecondArmyCount = ComputerArmy.Count;
            int Count = FirstArmyCount < SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            string result = "";

            for (int i = 0; i < Count; i++)
            {
                result += FightUnit(UserArmy[i], ComputerArmy[i]);
            }

            return result;
        }
    }
}
