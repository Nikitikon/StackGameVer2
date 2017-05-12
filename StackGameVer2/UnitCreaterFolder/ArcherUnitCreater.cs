using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArcherUnitCreater : IUnitCreater
    {
        public string Name { get; } = "Archer";
        public IUnit CreateUnit()
        {
            return new ArcherUnit();
        }
    }
}
