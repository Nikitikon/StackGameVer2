using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class TurtelCombatBuild : CombatBuild
    {
        public override string AbbilytySrategy(Army UserArmy, Army ComputerArmy, int TurnCounter)
        {
            if (UserArmy.UnitList.Count < 4)
                return "";
            if (ComputerArmy.UnitList.Count < 4)
                return "";

            int FirstArmyCount = UserArmy.UnitList.Count;
            int SecondArmyCount = ComputerArmy.UnitList.Count;
            int Count = FirstArmyCount > SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            IAbility UnitWithAbility;

            string result = "Фаза абилити\n";
            string UserStr = "Ваша армия: ";
            string ComputerStr = "\nАрмия противника: ";

            for (int i = 4; i < Count; i++)
            {
                if (i < FirstArmyCount)
                {
                    if (UserArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = UserArmy.UnitList[i] as IAbility;
                        UserStr += UnitWithAbility.DoAbility(UserArmy.UnitList, ComputerArmy.UnitList, i);
                    }
                }

                if (i < SecondArmyCount)
                {
                    if (ComputerArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = ComputerArmy.UnitList[i] as IAbility;
                        ComputerStr += UnitWithAbility.DoAbility(ComputerArmy.UnitList, UserArmy.UnitList, i);
                    }
                }

                UserArmy.RemoveTheDead(TurnCounter);
                ComputerArmy.RemoveTheDead(TurnCounter);
                FirstArmyCount = UserArmy.UnitList.Count;
                SecondArmyCount = ComputerArmy.UnitList.Count;
            }

            return result + UserStr + ComputerStr;
        }

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
