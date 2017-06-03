using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    interface IEngine
    {
        string NextTurn(out bool flag);
        Army UserArmy { get; }
        Army ComputerArmy { get; }
        void SetArmy(Army UserArmy, Army ComputerArmy);
        void ChangeCombutBuild(int num);
    }
}
