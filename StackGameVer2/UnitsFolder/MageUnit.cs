using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class MageUnit : IUnit, IAbility, ICanBeHealed
    {
        public int Armor { get; private set; } = 10;

        public int Cost { get; private set; } = 30;

        public int Damage { get; private set; } = 2;

        public int Health { get; private set; } = 10;

        public int Initiative { get; private set; } = 0;

        public int Range { get; private set; } = 1;

        public int AbilityDamage { get; private set; } = 0;

        public int Dexterity { get; private set; } = 0;

        public string Name { get; private set; } = "Mage Unit";

        public int MaxHealth { get; private set; } = 10;

        public bool GetHit(int hit)
        {
            Health -= hit;

            if (Health <= 0)
                return false;

            if (Health > MaxHealth)
                Health = MaxHealth;

            return true;
        }

        public string DoAbility(List<IUnit> Allies, List<IUnit> Enemies, int position)
        {
            string AbilityResult = "Mage at position " + position;

            for (int i = Range; i > -Range; i--)
            {
                if (Allies[position + i] is ICanBeDublacate)
                {
                    ICanBeDublacate CloneUnit = Allies[position + i] as ICanBeDublacate;
                    Random random = new Random();
                    int Chance = random.Next(1, 21);

                    if (Chance == 20)
                    {
                        Allies.Insert(position - 1, CloneUnit.Clone());
                        AbilityResult += string.Format(" cloned the {0} at position {1}", Allies[position + i].Name, position + i);
                        return AbilityResult;
                    }
                }
            }

            return AbilityResult + string.Format(" can't clone");
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5}, can clone unit", Name, Health, MaxHealth, Armor, Damage, Dexterity);
        }
    }
}
