using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaF_BattleSimulator.Model.Parent;

namespace SaF_BattleSimulator.Model
{
    public class Warrior : Character
    {
        public Warrior()
        {
            this.EscapePercent = 25;
            this.IgnoreArmor = false;
        }
    }
}
