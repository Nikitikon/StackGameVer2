using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class MageUnitCreater : IUnitCreater
    {
        public string Name { get; } = "Mage";
        
        public IUnit CreateUnit()
        {
            return new MageUnit();
        }
    }
}
