using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class Engine : IEngine
    {
        private static Engine instance;
        private static object syncRoot = new Object();
        public Army UserArmy { get; private set; }
        public Army ComputerArmy { get; private set; }
        private int counter;
        private int TurnCounter;
        private int FirstArmyCount;
        private int SecondArmyCount;
        private Dictionary<int, List<Army>> Turn;
        private CombatBuild combatBuild;

        private Engine()
        {
            counter = 0;
        }

        public void SetArmy(Army UserArmy, Army ComputerArmy)
        {
            if (UserArmy == null || ComputerArmy == null)
            {
                throw new Exception("Неправильно введена армия");
            }

            this.ComputerArmy = ComputerArmy;
            this.UserArmy = UserArmy;
            FirstArmyCount = UserArmy.UnitList.Count;
            SecondArmyCount = ComputerArmy.UnitList.Count;
            TurnCounter = 0;
            Turn = new Dictionary<int, List<Army>>();
            combatBuild = new LineCombatBuild();
        }

        public static Engine getInstance()
        {
            if (instance == null)
            { 
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Engine();
                }
            }
            return instance;
        }

        public string NextTurn(out bool flag)
        {

            if (UserArmy == null || ComputerArmy == null)
            {
                throw new Exception("Армии еще не созданы");
                flag = false;
            }

            TurnCounter++;

            flag = true;
            counter = 0;
            string result = "Новый Ход "+ TurnCounter +"\n\n"+combatBuild.FightStategy(UserArmy.UnitList, ComputerArmy.UnitList);
            UserArmy.RemoveTheDead(TurnCounter);
            UserArmy.RemoveTheDead(TurnCounter);
            result += "\n\n" + combatBuild.AbbilytySrategy(UserArmy, ComputerArmy, TurnCounter) + "\nКонец Хода\n";
            UserArmy.RemoveTheDead(TurnCounter);
            UserArmy.RemoveTheDead(TurnCounter);
            SafeState();
            string win = ChoseWiner(out flag);
            if (!flag)
            {
                throw new Exception(win);
            }
            FirstArmyCount = UserArmy.UnitList.Count;
            SecondArmyCount = ComputerArmy.UnitList.Count;
            return result;
        }

        private string ChoseWiner(out bool flag)
        {
            string result = null;
            flag = true;
            if (FirstArmyCount != 0 && SecondArmyCount == 0)
            {
                result = "Вы выйграли";
                flag = false;
            }

            if (FirstArmyCount == 0 && SecondArmyCount != 0)
            {
                result = "Вы проиграли";
                flag = false;
            }

            if (UserArmy.UnitList.Count == FirstArmyCount && ComputerArmy.UnitList.Count == SecondArmyCount)
            {
                counter++;
            }
            else { counter = 0; }

            if (counter == 10)
            {
                result = "Ничья";
                flag = false;
            }

            return result;
        }

        private void SafeState()
        {
            List<Army> LA = new List<Army>();
            LA.Add(UserArmy);
            LA.Add(ComputerArmy);
            for (int i = Turn.Count; i >= TurnCounter; i--)
            {
                Turn.Remove(i);
            }
            Turn.Add(TurnCounter, LA);
        }


        public void UnDo()
        {
            if(TurnCounter == 1 || TurnCounter == 0)
            {
                throw new Exception("Вы в начале");
            }

            TurnCounter--;
            UserArmy = Turn[TurnCounter][0];
            ComputerArmy = Turn[TurnCounter][1];
        }

        public void ReDo()
        {
            if (TurnCounter == Turn.Count)
            {
                throw new Exception("Вы в конце");
            }

            TurnCounter++;
            UserArmy = Turn[TurnCounter][0];
            ComputerArmy = Turn[TurnCounter][1];
        }

        public void ChangeCombutBuild(int num)
        {
            if (num > 3 || num < 1)
                throw new Exception("Неправильный ввод");

            if (num == 1)
                combatBuild = new LineCombatBuild();

            if (num == 2)
                combatBuild = new TurtelCombatBuild();

            if (num == 3)
                combatBuild = new RankCombutBuild();
        }
    }
}
