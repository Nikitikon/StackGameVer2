using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackGameVer2
{
    class ArmyCreater : IArmyCreater
    {
        public IUnit Create(string UnitName)
        {
            IUnitCreater creater = CreateUnit(UnitName);
            if (creater == null)
            {
                return null;
            }

            return creater.CreateUnit();
        }

        private IUnitCreater CreateUnit(string UnitName)
        {
            IUnitCreater creater;
            var types = GetType().Assembly.GetTypes().Where(t => typeof(IUnitCreater).IsAssignableFrom(t) && !t.IsAbstract).ToList();

            foreach (Type type in types)
            {
                creater = (IUnitCreater)Activator.CreateInstance(type);
                if (creater.Name.Equals(UnitName))
                {
                    return creater;
                }
            }

            return null;
        }
    }
}
