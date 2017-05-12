using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ClericUnitCreater : IUnitCreater
    {
        public string Name { get; } = "Cleric";

        public IUnit CreateUnit()
        {
            return new ClericUnit();
        }
    }
}
