using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class InfantryUnit : IUnit, ICanBeHealed, ICanBeDublacate
    {
        public int Armor { get; private set; } = 13;

        public int Cost { get; private set; } = 15;

        public int Damage { get; private set; } = 5;

        public int Dexterity { get; private set; } = 4;

        public int Health { get; private set; } = 15;

        public int Initiative { get; private set; } = 4;

        public int MaxHealth { get; private set; } = 16;

        public string Name { get; private set; } = "Infantry Unit";

        public IUnit Clone()
        {
            InfantryUnit unit = new InfantryUnit();
            unit.Health = Health;
            return unit;
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
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5}",Name, Health, MaxHealth, Armor, Damage, Dexterity);
        }
    }
}
