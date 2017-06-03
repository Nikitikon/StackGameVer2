using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
     abstract class Army : IObservable
    {
        public List<IUnit> UnitList { get; protected set; }
        public int Money { get; protected set; } = 100;
        protected int MoneyMax = 0; 
        protected ArmyCreater _ArmyCreater = new ArmyCreater();
        private Dictionary<int, string> UnitDic;
        private List<IObserver> observers;


        public Army(int Money)
        {

            if (Money < 15)
            {
                throw new Exception("Мало денег"); // написать свой
            }

            MoneyMax = Money;
            this.Money = Money;

            UnitDic = new Dictionary<int, string>();
            UnitDic.Add(1, "Archer");
            UnitDic.Add(2, "Armor");
            UnitDic.Add(3, "Cleric");
            UnitDic.Add(4, "Infantry");
            UnitDic.Add(5, "Mage");
            UnitDic.Add(6, "Gulyay-Gorod");
            observers = new List<IObserver>();
            AddObserver(new FileDeadLog());
            AddObserver(new BeebDeadLog());
        }

        public abstract int CreateArmy();
        

        public override string ToString()
        {
            if (UnitList == null)
            {
                throw new Exception("Армия еще не создана"); // exep
            }

            string CompositionOfTheArmy = "";
            for (int i = 0; i < UnitList.Count; i++)
            {
                CompositionOfTheArmy += UnitList[i].ToString() + '\n';
            }

            return CompositionOfTheArmy;
        }

        protected void ArmyAlgoritmCreater()
        {
            Random r = new Random();
            while (true)
            {
                int key = r.Next(1, 7);
                IUnit Unit = _ArmyCreater.Create(UnitDic[key]);
                bool flag = true;
                
                if (Money - Unit.Cost >= 0)
                {
                    Money -= Unit.Cost;
                    UnitList.Add(Unit);
                    flag = false;
                }
                
                if (flag)
                {
                    break;
                }
            }
        }

        public abstract void RemoveTheDead(int TurnCounter);

        public string UnitInfo (int Position)
        {
            if (UnitList == null)
            {
                throw new Exception("Армия еще не создана"); // exep
            }

            return UnitList[Position - 1].ToString();
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
    }
}
