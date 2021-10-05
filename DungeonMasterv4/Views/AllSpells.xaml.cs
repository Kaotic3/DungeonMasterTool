using DungeonMasterv4.Models;
using DungeonMasterv4.Models.Spells;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
    /// Interaction logic for AllSpells.xaml
    /// </summary>
    public partial class AllSpells : Window
    {
        public static System.Action CloseAction { get; set; }

        public string spellChoice { get; set; }
        string json;
        SpellListAPI.Rootobject spellsList;
        SpellAPI.Rootobject SpellDetails;

        public AllSpells()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillSpellList();
        }
        #region Logic
        public async void FillSpellList()
        {
            string url = "https://www.dnd5eapi.co";
            string equipmentCategories = "/api/spells";

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

            spellsList = JsonConvert.DeserializeObject<SpellListAPI.Rootobject>(json, settings);

            foreach (var cat in spellsList.results)
            {
                lbMagicSchools.Items.Add(cat.name);
            }
        }
        private void tbSchoolSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbSchoolSearch.Text.ToLower();

            lbMagicSchools.Items.Clear();

            foreach (var name in spellsList.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbMagicSchools.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbSchoolSearch.Text))
            {
                foreach (var name in spellsList.results)
                {
                    lbMagicSchools.Items.Add(name.name);
                }
            }
        }
        private void lbMagicSchools_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbMagicSchools.SelectedValue.ToString();

            foreach (var name in spellsList.results)
            {
                if (name.name == tempCat)
                {
                    spellChoice = name.url;
                    break;
                }
            }
            SelectedSpell(spellChoice);
        }
        public async void SelectedSpell(string spellSchool)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + spellSchool;

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

            SpellDetails = JsonConvert.DeserializeObject<SpellAPI.Rootobject>(json, settings);

            tbSpellDetails.Text = SpellDetails.name + "\n\n";

            if (SpellDetails?.desc != null)
            {
                foreach (var line in SpellDetails.desc)
                {
                    tbSpellDetails.Text += line + "\n";
                }
            }
            if (SpellDetails?.higher_level != null)
            {
                foreach (var newline in SpellDetails.higher_level)
                {
                    tbSpellDetails.Text += "\n" + newline + "\n";
                }
            }
            if (SpellDetails?.components != null)
            {
                tbSpellDetails.Text += "\nComponents: ";
                foreach (var newcomp in SpellDetails.components)
                {
                    tbSpellDetails.Text += newcomp + " ";
                }
                if (SpellDetails?.material != null)
                {
                    tbSpellDetails.Text += "\n" + SpellDetails?.material;
                }
                tbSpellDetails.Text += "\n";
            }
            tbSpellDetails.Text += "\n" + SpellDetails?.casting_time + "\n";
            if (SpellDetails ?.duration != null)
            {
                tbSpellDetails.Text += $"Duration: {SpellDetails?.duration}";
            }

            
        }
        #endregion
        #region Menu Options
        private void Armour_Click(object sender, RoutedEventArgs e)
        {
            Armour avm = new Armour();

            this.Close();
            avm.ShowDialog();
        }
        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAction();
        }

        private void btnSetUp_Click(object sender, RoutedEventArgs e)
        {
            SetUp spvm = new SetUp();

            spvm.Show();
        }
        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment avm = new Equipment();

            avm.Show();
        }

        private void btnAllSpells_Click(object sender, RoutedEventArgs e)
        {
            
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
            AllMonsters amvm = new AllMonsters();

            amvm.Show();
        }
        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            DiceRollsView drvm = new DiceRollsView();

            drvm.Show();
        }
        #endregion
    }
}
