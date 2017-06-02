using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecialUnits;

namespace StackGameVer2
{
    class MyGulyayGorod : IUnit
    {
        GulyayGorod GG = new GulyayGorod(20,0,15);

        public int Armor { get; private set; } = 12;

        public int Cost {
            get
            {
                return GG.GetCost();
            }
        }

        public int Damage { get; private set; } = 0;

        public int Health {
            get
            {
                return GG.GetCurrentHealth();
            }
        }

        public int Initiative { get; private set; } = 0;

        public int Dexterity { get; private set; } = 0;

        public string Name { get; private set; } = "Gulyay-Gorod";

        public bool GetHit(int hit)
        {
            GG.TakeDamage(hit);

            return !GG.IsDead;
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5} ", Name, GG.GetCurrentHealth(), GG.GetHealth(), GG.GetDefence(), Damage, Dexterity);
        }
    }
}
