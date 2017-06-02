using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArmorUnitShield : ArmorUnitAdapter
    {
        public ArmorUnitShield(IUnit Unit) : base(Unit)
        {
        }

        public override int Armor
        {
            get { return Unit.Armor + 3; }
        }

        public override int Cost
        {
            get { return Unit.Cost; }
        }

        public override int Damage
        {
            get { return Unit.Damage; }
        }

        public override int Dexterity
        {
            get { return Unit.Dexterity - 1; }
        }

        public override int Health
        {
            get { return Unit.Health; }
        }

        public override int Initiative
        {
            get { return Unit.Initiative; }
        }

        public override string Name
        {
            get { return Unit.Name + " With Shield"; }
        }

        public override IUnit Clone()
        {
            ICanBeDublacate dubl = Unit as ICanBeDublacate;
            ArmorUnitHelmet AUS = new ArmorUnitHelmet(dubl.Clone());
            return AUS;
        }

        public override bool GetHit(int hit)
        {
            return Unit.GetHit(hit);
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/12, Armor - {2}, Damage - {3}, Dexterity - {4} ", Name, Health, Armor, Damage, Dexterity);
        }
    }
}
