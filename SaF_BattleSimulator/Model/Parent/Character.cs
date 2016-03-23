using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaF_BattleSimulator.Model.Parent
{
    public class Character
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public double ArmoredPercent { get; set; }
        public int EscapePercent { get; set; }
        public int Evasion { get; set; }
        public int Resistance { get; set; }
        public int HitPoints { get; set; }
        public double CriticalHit { get; set; }
        public bool IgnoreArmor { get; set; }
        public int CurrentHitPoint { get; set; }

        public void Heal()
        {
            this.CurrentHitPoint = HitPoints;
        }
    }
}
