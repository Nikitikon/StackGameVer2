using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    abstract class CombatBuild
    {
        public string FightUnit(IUnit FirstUnit, IUnit SecondUnit)
        {
            int UnitFlag = 1;
            string result = string.Empty;
            IUnit AttackingUnit;
            IUnit DefendingUnit;

            Random random = new Random();
            int RandomForAttackingUnit = random.Next(1, 21);
            int RandomForDefendingUnit = random.Next(1, 21);

            if (RandomForAttackingUnit + FirstUnit.Initiative > RandomForDefendingUnit + SecondUnit.Initiative)
            {
                AttackingUnit = FirstUnit;
                DefendingUnit = SecondUnit;
                result += result += string.Format("{0} из вашей армии против {1} ", AttackingUnit.Name, DefendingUnit.Name);
            }
            else
            {
                AttackingUnit = SecondUnit;
                DefendingUnit = FirstUnit;
                UnitFlag = 2;
                result += result += string.Format("{0} из вражеской армии против {1} ", AttackingUnit.Name, DefendingUnit.Name);
            }



            bool DonaldTramp(IUnit Attacking, IUnit Defending)
            {
                int Rand = random.Next(1, 21);
                if (Rand + Attacking.Dexterity > Defending.Armor)
                {
                    return true;
                }
                return false;
            }
            bool IsAlive = true;


            if (DonaldTramp(AttackingUnit, DefendingUnit))
            {
                IsAlive = DefendingUnit.GetHit(AttackingUnit.Damage);
                result += string.Format("\nнаносит {0} урона противнику ", AttackingUnit.Damage);
            }
            else
            {
                result += "\nпромахивается по противнику ";
            }

            if (IsAlive)
            {
                if (DonaldTramp(DefendingUnit, AttackingUnit))
                {
                    IsAlive = AttackingUnit.GetHit(DefendingUnit.Damage);
                    result += string.Format("\nпроитвник наносит {0} урона ", DefendingUnit.Damage);
                }
                else
                {
                    result += "\nпротивник промахивается";
                }

            }
            else
            {
                result += "противник убит";
            }

            return result;
        }

        public abstract string FightStategy(List<IUnit> UserArmy, List<IUnit> ComputerArmy);

        public abstract string AbbilytySrategy(Army UserArmy, Army ComputerArmy, int TurnCounter);

    }
}
