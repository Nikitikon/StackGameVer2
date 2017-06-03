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
        ComputerArmy User;
        ComputerArmy Comp;
        IComand comand = new ComandForEngine();
        public void NewGame()
        {
            string menu = string.Format("Введите число: \n1 - Создать армию\n2 - Показать Армию\n3 - Начать игру\n4 - Выйти");
            string readAnsw = "";
            while (!readAnsw.Equals("4"))
            {
                Console.WriteLine(menu);
                readAnsw = Console.ReadLine();

                if (readAnsw.Equals("1"))
                {
                    CreateArmy();
                }

                if (readAnsw.Equals("2"))
                {
                    ShowArmy();
                }

                if (readAnsw.Equals("3"))
                {
                    try
                    {
                        engine.SetArmy(User, Comp);
                        Game();
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

                Console.Clear();
            }
        }

        private void CreateArmy()
        {
            Console.WriteLine("Введите деньги: ");
            int Money = 0;
            Money = int.Parse(Console.ReadLine());

            try
            { 
                User = new ComputerArmy(Money);
                Comp = new ComputerArmy(Money);

                User.CreateArmy();
                Comp.CreateArmy();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.WriteLine("Успешна создано\n");
            Console.Read();
        }

        private void ShowArmy()
        {
            Console.WriteLine("\nВаша Армия:\n"+User.ToString()+"\n");
            Console.Read();
        }

        private void Game()
        {
            Console.Clear();
            string menu = string.Format("Введите число: \n1 - Следующий ход\n2 - Показать Юнита\n3 - Отменить ход\n4 - Повторить ход\n5 - Показать армию\n6 - Сменить стратегию\n7 - Выйти");
            string readAnsw = "";
            while (!readAnsw.Equals("7"))
            {
                bool flag;
                Console.WriteLine(menu);
                readAnsw = Console.ReadLine();

                if (readAnsw.Equals("1"))
                {
                    Console.WriteLine(engine.NextTurn(out flag));
                }

                if (readAnsw.Equals("2"))
                {
                    Console.WriteLine("Введите позицию: ");
                    User.UnitInfo(int.Parse(Console.ReadLine()));
                }

                if (readAnsw.Equals("3"))
                {
                    try
                    {
                        comand.UnDo();
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

                if (readAnsw.Equals("4"))
                {
                    try
                    {
                        comand.ReDo();
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

                if (readAnsw.Equals("5"))
                {
                    try
                    {
                        ShowArmy();
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

                if (readAnsw.Equals("6"))
                {
                    try
                    {
                        string strateg = "Введите число: \n1 - Линия\n2 - Черепаха\n3 - Шеренга";
                        Console.WriteLine(strateg);
                        engine.ChangeCombutBuild(int.Parse(Console.ReadLine()));
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }

            }
        }

    }
}