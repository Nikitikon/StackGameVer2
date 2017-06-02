using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class InfantryUnitProxy : IUnit, ICanBeDublacate, ICanBeHealed, IAbility
    {
        private InfantryUnit IU = new InfantryUnit();

        public int Health => ((IUnit)IU).Health;

        public int Damage => ((IUnit)IU).Damage;

        public int Armor => ((IUnit)IU).Armor;

        public int Cost => ((IUnit)IU).Cost;

        public int Initiative => ((IUnit)IU).Initiative;

        public int Dexterity => ((IUnit)IU).Dexterity;

        public string Name => ((IUnit)IU).Name;

        public int MaxHealth => ((ICanBeHealed)IU).MaxHealth;

        public int AbilityDamage => ((IAbility)IU).AbilityDamage;

        public int Range => ((IAbility)IU).Range;

        public IUnit Clone()
        {
            InfantryUnitProxy IUP = new InfantryUnitProxy();
            IUP.IU = (InfantryUnit)IU.Clone();
            return IUP;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            Console.WriteLine( ((IAbility)IU).DoAbility(Allies, Enemies, position));
            return null;
        }

        public bool GetHit(int hit)
        {
            return ((IUnit)IU).GetHit(hit);
        }
    }
}
