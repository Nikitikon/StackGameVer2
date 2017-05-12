﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class InfantryUnitCreater : IUnitCreater
    {
        public string Name { get; } = "Infantry";

        public IUnit CreateUnit()
        {
            return new InfantryUnit();
        }
    }
}
