using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaF_BattleSimulator.Model.Parent;

namespace SaF_BattleSimulator.Model
{
    public class Hunter : Character
    {
        public Hunter()
        {
            this.EscapePercent = 50;
            this.IgnoreArmor = false;
        }
    }
}
