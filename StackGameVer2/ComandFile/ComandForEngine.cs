using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ComandForEngine : IComand
    {
        private Engine engine = Engine.getInstance();

        public void ReDo()
        {
            engine.ReDo();
        }

        public void UnDo()
        {
            engine.UnDo();
        }
    }
}
