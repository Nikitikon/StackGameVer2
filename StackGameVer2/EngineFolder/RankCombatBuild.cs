using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class RankCombutBuild : CombatBuild
    {
        public override string AbbilytySrategy(Army UserArmy, Army ComputerArmy, int TurnCounter)
        {
            int FirstArmyCount = UserArmy.UnitList.Count;
            int SecondArmyCount = ComputerArmy.UnitList.Count;
            int Count = FirstArmyCount < SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            string result = "Фаза абилити\n";
            List<IUnit> TempList = new List<IUnit>();
            List<IUnit> Target; List<IUnit> Enemy;
            IAbility UnitWithAbility;

            if (Count == UserArmy.UnitList.Count)
            {
                Target = ComputerArmy.UnitList;
                Enemy = UserArmy.UnitList;
                result +=  "Армия противника: ";
            }
            else
            {
                Target = UserArmy.UnitList;
                Enemy = ComputerArmy.UnitList;
                result += "Ваша армия: ";
            }

            for (int i = Count; i < Target.Count; i++)
            {
                TempList.Add(Target[i]);
            }

            for (int i = 0; i < TempList.Count; i++)
            {
                if (TempList[i] is IAbility)
                {
                    UnitWithAbility = TempList[i] as IAbility;
                    result += UnitWithAbility.DoAbility(TempList, Enemy, i);
                }
            }

            return result;
        }

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
