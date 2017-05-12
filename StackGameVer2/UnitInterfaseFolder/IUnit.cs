using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    interface IUnit
    {
        int Health { get; }
        int Damage { get; }
        int Armor { get; }
        int Cost { get; }
        int Initiative { get; }
        int Dexterity { get; }
        string Name { get; }
        bool GetHit(int hit);
    }
}
