using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class UserArmy : Army
    {

        public UserArmy(int Money) : base(Money) { }

        public override int CreateArmy()
        {
            if (UnitList == null)
            {
                UnitList = new List<IUnit>();
            }

            if (_ArmyCreater == null)
            {
                _ArmyCreater = new ArmyCreater();
            }

            return Money;
        }

        public int AddUnit(string UnitName)
        {
            CreateArmy();
            
            UnitList.Add(CreateUnit(UnitName));

            return Money;
        }

        public int DeleteUnit(int Position)
        {
            CreateArmy();

            if (Position > UnitList.Count || Position <= 0)
            {
                throw new Exception("Не правильная позиция"); //exep
            }

            Money += UnitList[Position - 1].Cost;
            UnitList.RemoveAt(Position - 1);

            return Money;
        }

        public int InsertUnit (int Position, string UnitName)
        {
            CreateArmy();

            if (Position > UnitList.Count || Position <= 0)
            {
                throw new Exception("Не правильная позиция"); //exep
            }

            UnitList.Insert(Position - 1,CreateUnit(UnitName));

            return Money; 
        }

        public int RandomArmy ()
        {
            UnitList.RemoveRange(0, UnitList.Count);
            Money = MoneyMax;
            ArmyAlgoritmCreater();

            return Money;
        }

        private IUnit CreateUnit(string UnitName)
        {
            IUnit Unit = _ArmyCreater.Create(UnitName);

            if (Unit == null)
            {
                throw new Exception("Не могу создать юнита"); // exep
            }

            if (Money - Unit.Cost < 0)
            {
                throw new Exception("Слишком мало денег");
            }

            Money -= Unit.Cost;

            return Unit;
        }

        public override void RemoveTheDead(int TurnCounter)
        {
            List<IUnit> DeadList = new List<IUnit>();
            foreach (IUnit Unit in UnitList)
            {
                if (Unit.Health <= 0)
                {
                    string deadUnit = string.Format("Ход {0} Ваша Армия: Юнит {1} на позиции {2}", TurnCounter, Unit.Name, UnitList.IndexOf(Unit));
                    NotifyObservers(deadUnit);
                    DeadList.Add(Unit);
                }
            }

            foreach (IUnit Unit in DeadList)
            {
                UnitList.Remove(Unit);
            }
        }
    }
}
