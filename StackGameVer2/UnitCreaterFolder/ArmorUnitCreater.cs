using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArmorUnitCreater : IUnitCreater
    {
        public string Name { get; } = "Armor";

        public IUnit CreateUnit()
        {
            return new ArmorUnit();
        }
    }
}
