﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    interface IArmyCreater
    {
        IUnit Create(string UnitName);
    }
}
