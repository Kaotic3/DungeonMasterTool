using DungeonMasterv4.Models;
using DungeonMasterv4.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonMasterv4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static System.Action CloseAction { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAction();
        }

        private void btnSetUp_Click(object sender, RoutedEventArgs e)
        {
            SetUp spvm = new SetUp();

            this.Close();
            spvm.Show();
        }
        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {

        }

        private void btnAllSpells_Click(object sender, RoutedEventArgs e)
        {
            AllSpells asvm = new AllSpells();

            this.Close();
            asvm.Show();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment eqvm = new Equipment();

            this.Close();
            eqvm.Show();
        }

        private void Conditions_Click(object sender, RoutedEventArgs e)
        {
            Conditions cvm = new Conditions();

            this.Close();
            cvm.Show();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            AllRules arvm = new AllRules();

            this.Close();
            arvm.Show();
        }

        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            PlayerClasses pcvm = new PlayerClasses();

            this.Close();
            pcvm.Show();
        }

        private void btnMonsters_Click(object sender, RoutedEventArgs e)
        {
            AllMonsters amvm = new AllMonsters();

            this.Close();
            amvm.Show();
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            DiceRollsView drvm = new DiceRollsView();

            drvm.Show();
        }
    }
}
