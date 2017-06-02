using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArcherUnitProxy : IUnit, IAbility, ICanBeDublacate, ICanBeHealed
    {
        private ArcherUnit AU = new ArcherUnit();

        public int Health => ((IUnit)AU).Health;

        public int Damage => ((IUnit)AU).Damage;

        public int Armor => ((IUnit)AU).Armor;

        public int Cost => ((IUnit)AU).Cost;

        public int Initiative => ((IUnit)AU).Initiative;

        public int Dexterity => ((IUnit)AU).Dexterity;

        public string Name => ((IUnit)AU).Name;

        public int AbilityDamage => ((IAbility)AU).AbilityDamage;

        public int Range => ((IAbility)AU).Range;

        public int MaxHealth => ((ICanBeHealed)AU).MaxHealth;

        public IUnit Clone()
        {
            ArcherUnitProxy IUP = new ArcherUnitProxy();
            IUP.AU = (ArcherUnit)AU.Clone();
            return IUP;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            Console.WriteLine( ((IAbility)AU).DoAbility(Allies, Enemies, position));
            return null;
        }

        public bool GetHit(int hit)
        {
            return ((IUnit)AU).GetHit(hit);
        }
    }
}
