using DungeonMasterv4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DungeonMasterv4.Views
{
    /// <summary>
    /// Interaction logic for AllMonsters.xaml
    /// </summary>
    public partial class AllMonsters : Window
    {
        public static System.Action CloseAction { get; set; }

        public string monsterChoice { get; set; }
        string json;
        MonsterListAPI.Rootobject monsterList;
        MonsterAPI.Rootobject monsterDetails;

        public AllMonsters()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillMonsterList();
        }
        #region Logic
        public async void FillMonsterList()
        {
            string url = "https://www.dnd5eapi.co";
            string equipmentCategories = "/api/monsters";

            string shorturl = url + equipmentCategories;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(shorturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            monsterList = JsonConvert.DeserializeObject<MonsterListAPI.Rootobject>(json, settings);

            foreach (var cat in monsterList.results)
            {
                lbMonsterList.Items.Add(cat.name);
            }
        }
        private void lbMonsterList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbMonsterList.SelectedValue.ToString();

            foreach (var name in monsterList.results)
            {
                if (name.name == tempCat)
                {
                    monsterChoice = name.url;
                    break;
                }
            }
            SelectedMonster(monsterChoice);
        }
        private void tbMonsterSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbMonsterSearch.Text.ToLower();

            lbMonsterList.Items.Clear();

            foreach (var name in monsterList.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbMonsterList.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbMonsterSearch.Text))
            {
                foreach (var name in monsterList.results)
                {
                    lbMonsterList.Items.Add(name.name);
                }
            }
        }
        public async void SelectedMonster(string monChoice)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + monChoice;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(shorturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            monsterDetails = JsonConvert.DeserializeObject<MonsterAPI.Rootobject>(json, settings);

            tbMonsterDetails.Text = $"{monsterDetails.name}; AC: {monsterDetails.armor_class}; HP: {monsterDetails.hit_points}\n\n";

            if (monsterDetails?.special_abilities != null)
            {
                foreach (var item in monsterDetails.special_abilities)
                {
                    tbMonsterDetails.Text += $"{item.desc}\n\n";
                }
            }
            foreach (var damage in monsterDetails.actions)
            {
                tbMonsterDetails.Text += $"{damage.desc}\n";
            }
            if (monsterDetails?.damage_immunities != null)
            {
                foreach (var immu in monsterDetails?.damage_immunities)
                {
                    tbMonsterDetails.Text += $"\nImmunities: {immu}\n";
                }
            }
            if (monsterDetails?.legendary_actions != null)
            {
                foreach (var leg in monsterDetails?.legendary_actions)
                {
                    tbMonsterDetails.Text += $"\nLegendary Actions: {leg.name}, ";
                    tbMonsterDetails.Text += $"{leg.desc}";
                }
            }
            if (monsterDetails?.damage_resistances != null)
            {
                foreach (var res in monsterDetails?.damage_resistances)
                {
                    tbMonsterDetails.Text += $"\nResistences: {res}\n";
                }
            }
            if (monsterDetails?.damage_vulnerabilities != null)
            {
                foreach (var vuln in monsterDetails?.damage_vulnerabilities)
                {
                    tbMonsterDetails.Text += $"Vulnerabilities: {vuln}\n";
                }
            }
            if (monsterDetails?.xp != null)
            {
                tbMonsterDetails.Text += $"\nXP: {monsterDetails.xp}\n";
            }
        }
        #endregion

        #region Menu Options
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAction();
        }

        private void btnSetUp_Click(object sender, RoutedEventArgs e)
        {
            SetUp spvm = new SetUp();

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

            asvm.Show();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment eqvm = new Equipment();

            eqvm.Show();
        }

        private void Conditions_Click(object sender, RoutedEventArgs e)
        {
            Conditions cvm = new Conditions();

            cvm.Show();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            AllRules arvm = new AllRules();

            arvm.Show();
        }

        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            PlayerClasses pcvm = new PlayerClasses();

            pcvm.Show();
        }

        private void btnMonsters_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            DiceRollsView drvm = new DiceRollsView();

            drvm.Show();
        }
        #endregion
    }
}
