﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class BeebDeadLog : IObserver
    {
        public void Update(object obj)
        {
            Console.Beep();
        }
    }
}