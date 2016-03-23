using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaF_BattleSimulator.Engine
{
    public class RandomEngine
    {
        private Random RandomForInstance { get; set; }

        public RandomEngine()
        {
            RandomForInstance = new Random();
        }

        public bool DoesItHappens(double chancesToHappen)
        {
            return RandomForInstance.NextDouble() < chancesToHappen / 100;
        }
    }
}
