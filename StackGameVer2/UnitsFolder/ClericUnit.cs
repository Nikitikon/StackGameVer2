using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ClericUnit : IUnit, IAbility, ICanBeDublacate, ICanBeHealed
    {
        public int Armor { get; private set; } = 10;

        public int Cost { get; private set; } = 30;

        public int Damage { get; private set; } = 3;

        public int Health { get; private set; } = 10;

        public int Initiative { get; private set; } = 0;

        public int Range { get; private set; } = 2;

        public int AbilityDamage { get; private set; } = -3;

        public int Dexterity { get; private set; } = 2;

        public string Name { get; private set; } = "Cleric Unit";

        public int MaxHealth { get; private set; } = 10;

        public bool GetHit(int hit)
        {
            Health -= hit;

            if (Health <= 0)
                return false;

            if (Health > MaxHealth)
                Health = MaxHealth;

            return true;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            string AbilityResult = "Cleric at position " + position;

            for (int i = Range; i > -Range; i--)
            {
                if (i + position >= Allies.Count || position + i < 0)
                {
                    continue;
                }
                if (Allies[position + i] is ICanBeHealed)
                {
                    ICanBeHealed HealetUnit = Allies[position + i] as ICanBeHealed;
                    if (HealetUnit.MaxHealth > Allies[position + i].Health)
                    {
                        Allies[position + i].GetHit(AbilityDamage);
                        AbilityResult += string.Format(" cured the {0} at position {1} by {2} points", Allies[position + i].Name, position + i, AbilityDamage);
                        return AbilityResult;
                    }
                }
            }

            return AbilityResult + string.Format(" can't heal");
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5}, can heal {6} times point ", Name, Health, MaxHealth, Armor, Damage, Dexterity, -AbilityDamage);
        }

        public IUnit Clone()
        {
            ClericUnit unit = new ClericUnit();
            unit.Health = Health;
            return unit;
        }
    }
}
