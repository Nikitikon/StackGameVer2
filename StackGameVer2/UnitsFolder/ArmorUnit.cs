using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArmorUnit : IUnit, ICanBeDublacate
    {
        public int Armor { get; private set; } = 16;

        public int Cost { get; private set; } = 20;

        public int Damage { get; private set; } = 6;

        public int Dexterity { get; private set; } = 3;

        public int Health { get; protected set; } = 12;

        public int Initiative { get; private set; } = 3;

        public string Name { get; private set; } = "Armoed Unit";

        public IUnit Clone()
        {
            ArmorUnit unit = new ArmorUnit();
            unit.Health = Health;
            return unit;
        }

        public bool GetHit(int hit)
        {
            Health -= hit;

            if (Health <= 0)
                return false;

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/12, Armor - {2}, Damage - {3}, Dexterity - {4} ", Name, Health, Armor, Damage, Dexterity);
        }
    }
}
