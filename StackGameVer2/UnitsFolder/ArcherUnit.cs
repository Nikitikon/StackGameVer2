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
            int EnemiesRange = Math.Abs(Range - position);
            int AlliesRange = position;

            if (Enemies == null)
            {
                return "";
            }

            if ((double)AlliesRange / Range >= 0.5)
            {
                AbilityResult += " did not shoot.\n";
                return AbilityResult;
            }

            Random RandomRange = new Random();
            int DamageRange = RandomRange.Next(0, Range + 1);
            if (DamageRange - position >= Enemies.Count)
            {
                AbilityResult += " did not shoot.\n";
                return AbilityResult;
            }
            if (DamageRange == 0)
            {
                AbilityResult += " missed\n";
                return AbilityResult;
            }

            if (DamageRange > AlliesRange)
            {
                Enemies[Math.Abs(DamageRange - position)].GetHit(AbilityDamage);
                AbilityResult += string.Format(" wounded enemy {0} at position {1}  by {2} points\n", Enemies[DamageRange - position].Name, DamageRange - position, AbilityDamage);
                return AbilityResult;
            }

            if (DamageRange <= AlliesRange)
            {
                Allies[DamageRange].GetHit(AbilityDamage);
                AbilityResult += string.Format(" wounded ally {0} at position {1}  by {2} points\n", Allies[DamageRange].Name, DamageRange, AbilityDamage);
                return AbilityResult;
            }

            return null;
        }

        public override string ToString()
        {
            return string.Format("{0}: Health - {1}/{2}, Armor - {3}, Damage - {4}, Dexterity - {5}, can shoot {6} times damaged\n", Name, Health, MaxHealth, Armor, Damage, Dexterity, AbilityDamage);
        }

        public IUnit Clone()
        {
            ArcherUnit unit = new ArcherUnit();
            unit.Health = Health;
            return unit;
        }
    }
}
