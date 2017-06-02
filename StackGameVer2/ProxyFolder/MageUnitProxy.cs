using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class MageUnitProxy : IUnit, IAbility, ICanBeHealed
    {
        MageUnit MU = new MageUnit();

        public int Health => ((IUnit)MU).Health;

        public int Damage => ((IUnit)MU).Damage;

        public int Armor => ((IUnit)MU).Armor;

        public int Cost => ((IUnit)MU).Cost;

        public int Initiative => ((IUnit)MU).Initiative;

        public int Dexterity => ((IUnit)MU).Dexterity;

        public string Name => ((IUnit)MU).Name;

        public int AbilityDamage => ((IAbility)MU).AbilityDamage;

        public int Range => ((IAbility)MU).Range;

        public int MaxHealth => ((ICanBeHealed)MU).MaxHealth;

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            Console.WriteLine( ((IAbility)MU).DoAbility(Allies, Enemies, position));
            return null;
        }

        public bool GetHit(int hit)
        {
            return ((IUnit)MU).GetHit(hit);
        }
    }
}
