using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StackGameVer2
{
    class UserInterface
    {
        IEngine engine = EngineProxy.getInstance();
        UserArmy User;
        ComputerArmy Comp; 
        public void NewGame()
        {
            string result = string.Format("Введите число: \n1 - Создать армию\n2 - Показать Армию\n3 - Начать игру\n4 - Выйти");
            string readAnsw = "";
            while (!readAnsw.Equals("4"))
            {
                readAnsw = Console.ReadLine();

                if (readAnsw.Equals("1"))
                {
                    try
                    {

                    }
                }
            }
        }




    }
}