using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class Engine : IEngine, IObservable
    {
        private static Engine instance;
        private static object syncRoot = new Object();
        public Army UserArmy { get; private set; }
        public Army ComputerArmy { get; private set; }
        private int counter;
        private int TurnCounter;
        private int FirstArmyCount;
        private int SecondArmyCount;
        private List<IObserver> observers;
        private Dictionary<int, List<Army>> Turn;

        private Engine()
        {
            counter = 0; observers = new List<IObserver>();
            AddObserver(new FileDeadLog());
            AddObserver(new BeebDeadLog());
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
            string result = "Новый Ход "+ TurnCounter +"\n\n"+Fight();
            result += "\n\n" + Abbiliti() + "\nКонец Хода\n";
            RemoveTheDead();
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

        private string Fight ()
        {
            int UnitFlag = 1;
            string result = string.Empty;
            IUnit AttackingUnit;
            IUnit DefendingUnit;

            Random random = new Random();
            int RandomForAttackingUnit = random.Next(1, 21);
            int RandomForDefendingUnit = random.Next(1, 21);

            if (RandomForAttackingUnit + UserArmy.UnitList[0].Initiative > RandomForDefendingUnit + ComputerArmy.UnitList[0].Initiative)
            {
                AttackingUnit = UserArmy.UnitList[0];
                DefendingUnit = ComputerArmy.UnitList[0];
                result += result += string.Format("{0} из вашей армии против {1} ", AttackingUnit.Name, DefendingUnit.Name);
            }
            else
            {
                AttackingUnit = ComputerArmy.UnitList[0];
                DefendingUnit = UserArmy.UnitList[0];
                UnitFlag = 2;
                result += result += string.Format("{0} из вражеской армии против {1} ", AttackingUnit.Name, DefendingUnit.Name);
            }

    

            bool DonaldTramp (IUnit Attacking, IUnit Defending)
            {
                int Rand = random.Next(1,21);
                if (Rand + Attacking.Dexterity > Defending.Armor)
                {
                    return true;
                }
                return false;
            }
            bool IsAlive = true;

            
            if (DonaldTramp(AttackingUnit, DefendingUnit))
            {
                IsAlive = DefendingUnit.GetHit(AttackingUnit.Damage);
                result += string.Format("\nнаносит {0} урона противнику ", AttackingUnit.Damage);
            }
            else
            {
                result += "\nпромахивается по противнику ";
            }

            if (IsAlive)
            {
                if (DonaldTramp(DefendingUnit, AttackingUnit))
                {
                    IsAlive = AttackingUnit.GetHit(DefendingUnit.Damage);
                    result += string.Format("\nпроитвник наносит {0} урона ", DefendingUnit.Damage);
                }
                else
                {
                    result += "\nпротивник промахивается";
                }
                
            }
            else
            {
                result += "противник убит";
            }

            RemoveTheDead();

            return result;
        }

        private string Abbiliti()
        {
            int FirstArmyCount = UserArmy.UnitList.Count;
            int SecondArmyCount = ComputerArmy.UnitList.Count;
            int Count = FirstArmyCount > SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            IAbility UnitWithAbility;

            string result = "Фаза абилити\n";
            string UserStr = "Ваша армия: ";
            string ComputerStr = "\nАрмия противника: ";

            for (int i = 1; i < Count; i++)
            {
                if (i < FirstArmyCount)
                {
                    if (UserArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = UserArmy.UnitList[i] as IAbility;
                        UserStr+= UnitWithAbility.DoAbility(UserArmy.UnitList, ComputerArmy.UnitList, i);
                    }
                }

                if (i < SecondArmyCount)
                {
                    if (ComputerArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = ComputerArmy.UnitList[i] as IAbility;
                        ComputerStr+= UnitWithAbility.DoAbility(ComputerArmy.UnitList, UserArmy.UnitList, i);
                    }
                }

                RemoveTheDead();
                FirstArmyCount = UserArmy.UnitList.Count;
                SecondArmyCount = ComputerArmy.UnitList.Count;
            }

            return result + UserStr + ComputerStr;
        }

        private void RemoveTheDead()
        {
            List<IUnit> DeadList = new List<IUnit>();
            foreach (IUnit Unit in UserArmy.UnitList)
            {
                if (Unit.Health <= 0)
                {
                    string deadUnit = string.Format("Ход {0} Ваша Армия: Юнит {1} на позиции {2}", TurnCounter, Unit.Name, UserArmy.UnitList.IndexOf(Unit));
                    NotifyObservers(deadUnit);
                    DeadList.Add(Unit);
                }
            } 

            foreach (IUnit Unit in DeadList)
            {
                UserArmy.UnitList.Remove(Unit);
            }

            DeadList.RemoveRange(0, DeadList.Count);

            foreach (IUnit Unit in ComputerArmy.UnitList)
            {
                if (Unit.Health <= 0)
                {
                    string deadUnit = string.Format("Ход {0} Армия Противника: Юнит {1} на позиции {2}", TurnCounter, Unit.Name, ComputerArmy.UnitList.IndexOf(Unit));
                    NotifyObservers(deadUnit);
                    DeadList.Add(Unit);
                }
            }
            foreach (IUnit Unit in DeadList)
            {
                ComputerArmy.UnitList.Remove(Unit);
            }
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(object obj)
        {
            foreach (IObserver observer in observers)
                observer.Update(obj); 
        }

        public void UnDo()
        {
            if(TurnCounter == 1)
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


    }
}
