using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    abstract class ArmorUnitAdapter : ArmorUnit
    {
        protected ArmorUnit Unit;

        public ArmorUnitAdapter(ArmorUnit Unit)
        {
            this.Unit = Unit;
        }

        public abstract int Armor { get; }

        public abstract int Cost { get; }

        public abstract int Damage { get; }

        public abstract int Dexterity { get; }

        public abstract int Health { get; }

        public abstract int Initiative { get; }

        public abstract string Name { get; }

        public abstract IUnit Clone();

        public abstract bool GetHit(int hit);

    }
}
