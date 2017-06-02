﻿using System;
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
        private int counter = 0;
        private int FirstArmyCount;
        private int SecondArmyCount;
        private StringBuilder TurnResul = new StringBuilder();


        private Engine() {}

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
            if (FirstArmyCount != 0 && SecondArmyCount == 0)
            {
                throw new Exception("Вы выйграли");
                flag = false;
            }

            if (FirstArmyCount == 0 && SecondArmyCount != 0)
            {
                throw new Exception("Вы проиграли");
                flag = false;
            }

            if (UserArmy.UnitList.Count == FirstArmyCount && ComputerArmy.UnitList.Count == SecondArmyCount)
            {
                counter++;
            }
            else { counter = 0; }

            if (counter == 10)
            {
                throw new Exception("Ничья");
                flag = false;
            }

            flag = true;
            counter = 0;
            string result = Fight();
            Abbiliti();
            RemoveTheDead();
            FirstArmyCount = UserArmy.UnitList.Count;
            SecondArmyCount = ComputerArmy.UnitList.Count;
            return result;
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

            if (UnitFlag == 1)
            {
                 UserArmy.UnitList[0] = AttackingUnit;
                 ComputerArmy.UnitList[0] = DefendingUnit;
            }
            else
            {
                UserArmy.UnitList[0] = DefendingUnit;
                ComputerArmy.UnitList[0] = AttackingUnit;
            }

            RemoveTheDead();

            return result + "\nХод окончен\n\n";
        }

        private void Abbiliti()
        {
            int FirstArmyCount = UserArmy.UnitList.Count;
            int SecondArmyCount = ComputerArmy.UnitList.Count;
            int Count = FirstArmyCount > SecondArmyCount ? FirstArmyCount : SecondArmyCount;
            IAbility UnitWithAbility;

            for (int i = 1; i < Count; i++)
            {
                if (i < FirstArmyCount)
                {
                    if (UserArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = UserArmy.UnitList[i] as IAbility;
                        UnitWithAbility.DoAbility(UserArmy.UnitList, ComputerArmy.UnitList, i);
                    }
                }

                if (i < SecondArmyCount)
                {
                    if (ComputerArmy.UnitList[i] is IAbility)
                    {
                        UnitWithAbility = ComputerArmy.UnitList[i] as IAbility;
                        UnitWithAbility.DoAbility(ComputerArmy.UnitList, UserArmy.UnitList, i);
                    }
                }

                RemoveTheDead();
                FirstArmyCount = UserArmy.UnitList.Count;
                SecondArmyCount = ComputerArmy.UnitList.Count;
            }
        }

        private void RemoveTheDead()
        {
            List<IUnit> DeadList = new List<IUnit>();
            foreach (IUnit Unit in UserArmy.UnitList)
            {
                if (Unit.Health <= 0)
                {
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
                    DeadList.Add(Unit);
                }
            }
            foreach (IUnit Unit in DeadList)
            {
                ComputerArmy.UnitList.Remove(Unit);
            }
        }
    }
}
