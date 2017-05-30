using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class InfantryUnit : IUnit, ICanBeHealed, ICanBeDublacate, IAbility
    {
        public int Armor { get; private set; } = 13;

        public int Cost { get; private set; } = 15;

        public int Damage { get; private set; } = 5;

        public int Dexterity { get; private set; } = 5;

        public int Health { get; private set; } = 15;

        public int Initiative { get; private set; } = 4;

        public int MaxHealth { get; private set; } = 15;

        public string Name { get; private set; } = "Infantry Unit";

        public int AbilityDamage { get; private set; } = 0;

        public int Range { get; private set; } = 1;

        public IUnit Clone()
        {
            InfantryUnit unit = new InfantryUnit();
            unit.Health = Health;
            return unit;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            string AbilityResult = "Infantry Unit at position " + position;
            int ArmorUnitPosition = 0;
            Random r = new Random();

            if (position + 1 < Allies.Count)
            {
                if (Allies[position + 1] is ArmorUnit)
                    ArmorUnitPosition = position + 1;
            }

            if (position - 1 > 0)
            {
                if (Allies[position - 1] is ArmorUnit)
                    ArmorUnitPosition = position - 1;
            }

            if (ArmorUnitPosition != 0 && r.Next(1, 21) == 20)
            {
                AbilityResult += string.Format(" equipment Armor Unit at position {0}", ArmorUnitPosition);
                ArmorUnit Unit = Allies[ArmorUnitPosition] as ArmorUnit;
                if(!(Unit is ArmorUnitAdapter))
                {
                    Allies[ArmorUnitPosition] = new ArmorUnitShield(Unit);
                    return AbilityResult + " Shield";
                }

                if (Unit is ArmorUnitShield)
                {
                    Allies[ArmorUnitPosition] = new ArmorUnitHelmet(Unit);
                    return AbilityResult + " Helmet";
                }

                if (Unit is ArmorUnitHelmet)
                {
                    Allies[ArmorUnitPosition] = new ArmorUnitHorse(Unit);
                    return AbilityResult + " Horse";
                }

                if (Unit is ArmorUnitHorse)
                {
                    Allies[ArmorUnitPosition] = new ArmorUnitSpear(Unit);
                    return AbilityResult + " Spear";
                }
            }

            return AbilityResult + string.Format(" can't equip");
        }

        public bool GetHit(int hit)
        {
            Health -= hit;

            if (Health <= 0)
                return false;

            if (Health > MaxHealth)
                Health = MaxHealth;

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5} ",Name, Health, MaxHealth, Armor, Damage, Dexterity);
        }
    }
}
