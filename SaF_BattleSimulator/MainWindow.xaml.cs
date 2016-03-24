using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using SaF_BattleSimulator.Engine;
using SaF_BattleSimulator.Model;

namespace SaF_BattleSimulator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int SimulationQuantity { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SimulationQuantity = 100000;
            int[] results = new int[SimulationQuantity];
            RandomEngine randomEngine = new RandomEngine();

            Warrior player1 = new Warrior()
            {
                Name = "Moi",
                Damage = 3906,
                ArmoredPercent = 50 / 100.0,
                HitPoints = 67025,
                CriticalHit = 23.08
            };


            Warrior player2 = new Warrior()
            {
                Name = "Lui",
                Damage = 5234,
                ArmoredPercent = 41 / 100.0,
                HitPoints = 39190,
                CriticalHit = 22.08
            };

            for (int i = 0; i < results.Length; i++)
            {
                FightEngine fight = new FightEngine(player1, player2, randomEngine);
                results[i] = fight.StartSimulation().Name == player1.Name ? 1 : 2;
            }

            double winRate = results.Count(x => x == 1) * 100.0 / results.Length;
            MessageBox.Show("Player1 won " + winRate + "% of games");
        }
    }
}
