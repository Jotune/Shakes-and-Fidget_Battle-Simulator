using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaF_BattleSimulator.Model.Parent;

namespace SaF_BattleSimulator.Engine
{
    public class FightEngine
    {
        public RandomEngine RandomEngine { get; set; }
        public Character[] Characters { get; set; }
        public int StrokesFired { get; set; }

        public FightEngine(Character player1, Character player2, RandomEngine randomEngine)
        {
            RandomEngine = randomEngine;
            Characters = new[] { player1, player2 };
            StrokesFired = 0;
        }

        public Character StartSimulation()
        {
            int characterPlaying = RandomEngine.DoesItHappens(50) ? 0 : 1;

            do
            {
                characterPlaying = (characterPlaying + 1) % 2;
                Debug.WriteLine(Characters[characterPlaying].Name + " is Attacking");
                if (!this.DoesDefenderEscape(characterPlaying))
                {
                    var dmg = this.CalculateDamage(characterPlaying);
                    Characters[(characterPlaying + 1) % 2].CurrentHitPoint -= dmg;
                    Debug.WriteLine(Characters[characterPlaying].Name + " inflige " + dmg + " dégats");
                }
                else
                {
                    Debug.WriteLine(Characters[(characterPlaying + 1) % 2].Name + " Esquive !");
                }
                this.StrokesFired++;

                Debug.WriteLine(Characters[(characterPlaying + 1) % 2].Name + " " + Characters[(characterPlaying + 1) % 2].CurrentHitPoint + "HP");
                Debug.WriteLine("=======================");
            } while (!this.IsGameOver(characterPlaying));

            foreach (var character in Characters)
            {
                character.Heal();
            }

            return Characters[characterPlaying];
        }

        private bool DoesDefenderEscape(int playerAttacking)
        {
            //Si mage
            return Characters[playerAttacking].IgnoreArmor ? false : RandomEngine.DoesItHappens(Characters[(playerAttacking + 1) % 2].EscapePercent);
        }

        private bool DoesAttackerCrit(int playerAttacking)
        {
            return RandomEngine.DoesItHappens(Characters[playerAttacking].CriticalHit);
        }

        private int CalculateDamage(int playerAttacking)
        {
            var attackerDamage = this.DoesAttackerCrit(playerAttacking) ? Characters[playerAttacking].Damage * 2 : Characters[playerAttacking].Damage;
            if (!Characters[playerAttacking].IgnoreArmor)
            {
                return ApplyTurnBasedDamageMultplier(attackerDamage - (attackerDamage * Characters[(playerAttacking + 1) % 2].ArmoredPercent));
            }

            return ApplyTurnBasedDamageMultplier(attackerDamage);
        }

        private int ApplyTurnBasedDamageMultplier(double initialDamage)
        {
            return (int)Math.Ceiling(initialDamage + (initialDamage * StrokesFired * .2));
        }

        private bool IsGameOver(int playerAttacking)
        {
            return Characters[(playerAttacking + 1) % 2].CurrentHitPoint <= 0;
        }
    }
}
