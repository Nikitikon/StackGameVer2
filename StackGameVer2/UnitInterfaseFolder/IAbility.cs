using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    interface IAbility
    {
        int AbilityDamage { get; }
        int Range { get; }

        string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position);
    }
}
