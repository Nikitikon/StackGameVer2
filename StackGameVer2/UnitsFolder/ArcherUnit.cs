using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArcherUnit : IUnit, IAbility, ICanBeDublacate, ICanBeHealed
    {
        public int Armor { get; private set; } = 11;

        public int Cost { get; private set; } = 25;

        public int Damage { get; private set; } = 2;

        public int Health { get; private set; } = 12;

        public int Initiative { get; private set; } = 1;

        public int Range { get; private set; } = 10;

        public int AbilityDamage { get; private set; } = 6;

        public int Dexterity { get; private set; } = 1;

        public string Name { get; private set; } = "Archer Unit";

        public int MaxHealth { get; private set; } = 12;

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
            string AbilityResult = "Archer at position " + position;
            int AlliesRange = Range - position + 1;
            int EnemiesRange = Range - AlliesRange;

            if (AlliesRange / Range > 0.5)
            {
                AbilityResult += " did not shoot.";
                return AbilityResult;
            }

            Random RandomRange = new Random();
            int DamageRange = RandomRange.Next(0, Range + 1);

            if (DamageRange > AlliesRange)
            {
                Enemies[EnemiesRange].GetHit(AbilityDamage);
                AbilityResult += string.Format(" wounded enemy {0} at position {1}  by {2} points", Enemies[EnemiesRange].Name, EnemiesRange, AbilityDamage);
                return AbilityResult;
            }

            if (DamageRange <= AlliesRange)
            {
                Allies[AlliesRange].GetHit(AbilityDamage);
                AbilityResult += string.Format(" wounded ally {0} at position {1}  by {2} points", Allies[AlliesRange].Name, AlliesRange, AbilityDamage);
                return AbilityResult;
            }

            if (DamageRange == 0)
            {
                AbilityResult += " missed";
                return AbilityResult;
            }

            return null;
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5}, can shoot {6} times damaged", Name, Health, MaxHealth, Armor, Damage, Dexterity, AbilityDamage);
        }

        public IUnit Clone()
        {
            ArcherUnit unit = new ArcherUnit();
            unit.Health = Health;
            return unit;
        }
    }
}
