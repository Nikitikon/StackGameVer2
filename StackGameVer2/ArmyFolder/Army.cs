using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
     abstract class Army
    {
        public List<IUnit> UnitList { get; protected set; }
        public int Money { get; protected set; } = 100;
        protected int MoneyMax = 0; 
        protected IArmyCreater _ArmyCreater;


        public Army(int Money)
        {

            if (Money < 15)
            {
                throw new Exception("Мало денег"); // написать свой
            }

            MoneyMax = Money;
            this.Money = Money;
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
            while (true)
            {
                IUnit Unit;
                IUnitCreater creater;
                bool flag = true;
                var types = GetType().Assembly.GetTypes().Where(t => typeof(IUnitCreater).IsAssignableFrom(t) && !t.IsAbstract).ToList();

                foreach (Type type in types)
                {
                    creater = (IUnitCreater)Activator.CreateInstance(type);
                    Unit = _ArmyCreater.Create(creater.Name);
                    if (Money - Unit.Cost >= 0)
                    {
                        Money -= Unit.Cost;
                        UnitList.Add(Unit);
                        flag = false;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        public string UnitInfo (int Position)
        {
            if (UnitList == null)
            {
                throw new Exception("Армия еще не создана"); // exep
            }

            return UnitList[Position - 1].ToString();
        }
    }
}
