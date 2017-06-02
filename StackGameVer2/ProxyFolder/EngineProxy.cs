using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2 
{
    class EngineProxy : IEngine
    {
        private Engine engine = Engine.getInstance();

        private static EngineProxy instance;
        private static object syncRoot = new Object();
        public Army UserArmy
        {
            get
            {
                return engine.UserArmy;
            }
        }

        public Army ComputerArmy
        {
            get
            {
                return engine.ComputerArmy;
            }
        }

        private EngineProxy() { }

        public static EngineProxy getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new EngineProxy();
                }
            }
            return instance;
        }

        public string NextTurn(out bool flag)
        {
            flag = false;
            string result = string.Empty;
            try
            {
                result = engine.NextTurn(out flag);
            }
            catch (Exception e) { result = e.Message; }
            using (StreamWriter sw = new StreamWriter("GameLog.txt", true, Encoding.Default))
            {
                sw.WriteLine(result);
            }
            return result;
        }

        public void SetArmy(Army UserArmy, Army ComputerArmy)
        {
            using (StreamWriter sw = new StreamWriter("DeadLog.txt", false, Encoding.Default))
            {
                sw.WriteLine(string.Empty);
            }
            try
            {
                engine.SetArmy(UserArmy, ComputerArmy);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
