using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ClericUnitProxy : IUnit, IAbility, ICanBeDublacate, ICanBeHealed
    {
        private ClericUnit CU = new ClericUnit();

        public int Health => ((IUnit)CU).Health;

        public int Damage => ((IUnit)CU).Damage;

        public int Armor => ((IUnit)CU).Armor;

        public int Cost => ((IUnit)CU).Cost;

        public int Initiative => ((IUnit)CU).Initiative;

        public int Dexterity => ((IUnit)CU).Dexterity;

        public string Name => ((IUnit)CU).Name;

        public int AbilityDamage => ((IAbility)CU).AbilityDamage;

        public int Range => ((IAbility)CU).Range;

        public int MaxHealth => ((ICanBeHealed)CU).MaxHealth;

        public IUnit Clone()
        {
            ClericUnitProxy IUP = new ClericUnitProxy();
            IUP.CU = (ClericUnit)CU.Clone();
            return IUP;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            Console.WriteLine( ((IAbility)CU).DoAbility(Allies, Enemies, position));
            return null;
        }

        public bool GetHit(int hit)
        {
            return ((IUnit)CU).GetHit(hit);
        }
    }
}
