using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class FileDeadLog : IObserver
    {

        public FileDeadLog()
        {
            using (StreamWriter sw = new StreamWriter("DeadLog.txt", false, Encoding.Default))
            {
                sw.WriteLine(string.Empty);
            }
        }

        public void Update(object obj)
        {
            if (!(obj is string))
            {
                throw new Exception("Енто не строка, а я обсервер");
            }
            string inform = (string)obj;
            using (StreamWriter sw = new StreamWriter("DeadLog.txt", true, Encoding.Default))
            {
                sw.WriteLine(inform);
            }
        }
    }
}
