using DungeonMasterv4.Models;
using DungeonMasterv4.Models.EquipmentCat;
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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        public static System.Action CloseAction { get; set; }

        public string equipmentCategory { get; set; }
        public string equipmentChoice { get; set; }
        string json;
        EquipmentListAPI.Rootobject catList;
        AdventuringGear.Rootobject catChoice;
        ItemsDetails.Rootobject catDetails;

        #region Logic
        public Equipment()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillCatList();
        }
        public async void FillCatList()
        {
            string url = "https://www.dnd5eapi.co";
            string equipmentCategories = "/api/equipment-categories";

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

            catList = JsonConvert.DeserializeObject<EquipmentListAPI.Rootobject>(json, settings);

            foreach (var cat in catList.results)
            {
                lbEquipCat.Items.Add(cat.name);
            }
        }
        private void tbCatSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbCatSearch.Text.ToLower();

            lbEquipCat.Items.Clear();

            foreach (var name in catList.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbEquipCat.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbCatSearch.Text))
            {
                foreach (var name in catList.results)
                {
                    lbEquipCat.Items.Add(name.name);
                }
            }
        }
        private void lbEquipCat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbEquipCat.SelectedValue.ToString();

            foreach (var name in catList.results)
            {
                if (name.name == tempCat)
                {
                    equipmentCategory = name.url;
                    break;
                }
            }

            SelectedCategory(equipmentCategory);
        }
        public async void SelectedCategory(string catName)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + catName;

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

            catChoice = JsonConvert.DeserializeObject<AdventuringGear.Rootobject>(json, settings);

            lbCatList.Items.Clear();

            foreach (var choice in catChoice.equipment)
            {
                lbCatList.Items.Add(choice.name);
            }
        }
        private void tbListSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbListSearch.Text.ToLower();

            lbCatList.Items.Clear();

            foreach (var name in catChoice.equipment)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbCatList.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbListSearch.Text))
            {
                foreach (var name in catChoice.equipment)
                {
                    lbCatList.Items.Add(name.name);
                }
            }
        }
        private void lbCatList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbCatList.SelectedValue.ToString();

            foreach (var name in catChoice.equipment)
            {
                if (name.name == tempCat)
                {
                    equipmentChoice = name.url;
                    break;
                }
            }

            SelectedDetails(equipmentChoice);
        }
        public async void SelectedDetails(string equipChoice)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + equipChoice;

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

            catDetails = JsonConvert.DeserializeObject<ItemsDetails.Rootobject>(json, settings);

            tbCatDetails.Text = catDetails.name + "\n";

            if (catDetails.gear_category?.name != null)
            {
                tbCatDetails.Text += $"\nType of Gear: {catDetails.gear_category?.name}\n";
            }
            if (catDetails?.weapon_range != null)
            {
                tbCatDetails.Text += $"\nWeapon Range: {catDetails?.weapon_range}\n";
                tbCatDetails.Text += $"Weapon Damage: {catDetails?.damage?.damage_dice}\n";
                tbCatDetails.Text += $"Weapon Damage: {catDetails?.damage?.damage_type.name}\n";
            }
            if (catDetails?.armor_class?._base != null)
            {
                tbCatDetails.Text += $"\nArmour Class: {catDetails?.armor_class?._base}\n";
                tbCatDetails.Text += $"Armour Size: {catDetails?.armor_category}\n";
            }

            if (catDetails?.desc != null)
            {
                tbCatDetails.Text += $"\nDescription: ";
                foreach (var line in catDetails?.desc)
                {
                    tbCatDetails.Text += line + "\n";
                }
                tbCatDetails.Text += "\n";
            }
            else
            {
                tbCatDetails.Text += $"\n";
            }
            tbCatDetails.Text += $"Cost: {catDetails?.cost?.quantity}{catDetails?.cost?.unit}\n";
            tbCatDetails.Text += $"Weight: {catDetails?.weight}";

        }
        #endregion

        #region Menu Items
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

        }

        private void btnAllSpells_Click(object sender, RoutedEventArgs e)
        {
            AllSpells asvm = new AllSpells();

            asvm.Show();
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
