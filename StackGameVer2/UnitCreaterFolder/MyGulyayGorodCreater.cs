using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class MyGulyayGorodCreater : IUnitCreater
    {
        public string Name { get; } = "Gulyay-Gorod";
        public IUnit CreateUnit()
        {
            return new MyGulyayGorod();
        }
    }
}
