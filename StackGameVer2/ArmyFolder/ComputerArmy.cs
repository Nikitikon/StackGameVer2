using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ComputerArmy : Army
    {
        
        public ComputerArmy(int Money) : base(Money)
        {
            
        }

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

            ArmyAlgoritmCreater();

            return Money;
        }

        public override void RemoveTheDead(int TurnCounter)
        {
            List<IUnit> DeadList = new List<IUnit>();
            foreach (IUnit Unit in UnitList)
            {
                if (Unit.Health <= 0)
                {
                    string deadUnit = string.Format("Ход {0} Армия Противника: Юнит {1} на позиции {2}", TurnCounter, Unit.Name, UnitList.IndexOf(Unit));
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
