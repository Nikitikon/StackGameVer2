using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class Engine
    {
        private static Engine instance;
        private static object syncRoot = new Object();
        public Army FirstArmy { get; private set; }
        public Army SecondArmy { get; private set; }
        private StringBuilder TurnResul = new StringBuilder();


        private Engine() {}

        public void SetArmy(Army FisrstArmy, Army SecondArmy)
        {
            if (FirstArmy == null || SecondArmy == null)
            {
                throw new Exception("Неправильно введена армия");
            }

            this.SecondArmy = SecondArmy;
            this.FirstArmy = FirstArmy;
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

        public bool NextTurn()
        {
            if (FirstArmy.UnitList.Count == 0 || SecondArmy.UnitList.Count == 0)
            {
                return false;
            }
            Fight();
            Abbiliti();
            RemoveTheDead();
            return true;
        }

        private void Fight ()
        {
            int UnitFlag = 1;

            IUnit AttackingUnit;
            IUnit DefendingUnit;

            Random random = new Random();
            int RandomForAttackingUnit = random.Next(1, 21);
            int RandomForDefendingUnit = random.Next(1, 21);

            if (RandomForAttackingUnit + FirstArmy.UnitList[0].Initiative > RandomForDefendingUnit + SecondArmy.UnitList[0].Initiative)
            {
                AttackingUnit = FirstArmy.UnitList[0];
                DefendingUnit = SecondArmy.UnitList[0];
            }
            else
            {
                AttackingUnit = SecondArmy.UnitList[0];
                DefendingUnit = FirstArmy.UnitList[0];
                UnitFlag = 2;
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
            }

            if (IsAlive)
            {
                AttackingUnit.GetHit(DefendingUnit.Damage);
            }

            if (UnitFlag == 1)
            {
                 FirstArmy.UnitList[0] = AttackingUnit;
                 SecondArmy.UnitList[0] = DefendingUnit;
            }
            else
            {
                FirstArmy.UnitList[0] = DefendingUnit;
                SecondArmy.UnitList[0] = AttackingUnit;
            }

            RemoveTheDead();
        }

        private void Abbiliti()
        {
            int FirstArmyCount = FirstArmy.UnitList.Count;
            int SecondArmyCount = SecondArmy.UnitList.Count;
            int Count = FirstArmyCount > SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            IAbility UnitWithAbility;

            for (int i = 1; i < Count; i++)
            {
                if (i < FirstArmyCount)
                {
                    if (FirstArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = FirstArmy.UnitList[i] as IAbility;
                        UnitWithAbility.DoAbility(FirstArmy.UnitList, SecondArmy.UnitList, i);
                    }
                }

                if (i < SecondArmyCount)
                {
                    if (SecondArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = SecondArmy.UnitList[i] as IAbility;
                        UnitWithAbility.DoAbility(SecondArmy.UnitList, FirstArmy.UnitList, i);
                    }
                }

                RemoveTheDead();
                FirstArmyCount = FirstArmy.UnitList.Count;
                SecondArmyCount = SecondArmy.UnitList.Count;
            }
        }

        private void RemoveTheDead()
        {
            List<IUnit> DeadList = new List<IUnit>();
            foreach (IUnit Unit in FirstArmy.UnitList)
            {
                if (Unit.Health <= 0)
                {
                    DeadList.Add(Unit);
                }
            }

            foreach (IUnit Unit in DeadList)
            {
                FirstArmy.UnitList.Remove(Unit);
            }

            DeadList.RemoveRange(0, DeadList.Count);

            foreach (IUnit Unit in SecondArmy.UnitList)
            {
                if (Unit.Health <= 0)
                {
                    DeadList.Add(Unit);
                }
            }
            foreach (IUnit Unit in DeadList)
            {
                SecondArmy.UnitList.Remove(Unit);
            }
        }
    }
}
