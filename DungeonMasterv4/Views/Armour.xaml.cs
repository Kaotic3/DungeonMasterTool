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
    /// Interaction logic for Armour.xaml
    /// </summary>
    public partial class Armour : Window
    {
        public string singleArmour { get; set; }
        string json;
        ArmourAPI.Rootobject token;
        ArmourSingle.Rootobject token2;
        public static System.Action CloseAction { get; set; }
        public Armour()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            ArmourListBoxFill();
        }
        public Armour(string mon)
        {

        }
        public async void ArmourListBoxFill()
        {
            string url = "https://www.dnd5eapi.co/";
            string creatureChoice = "api/equipment-categories/armor";

            string shorturl = url + creatureChoice;

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

            token = JsonConvert.DeserializeObject<ArmourAPI.Rootobject>(json, settings);

            foreach (var name in token.equipment)
            {
                lbArmourList.Items.Add(name.name);
            }

        }
        private void lbArmourList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempMon = lbArmourList.SelectedValue.ToString();

            foreach (var name in token.equipment)
            {
                if (name.name == tempMon)
                {
                    singleArmour = name.url;
                    break;
                }
            }
            SelectedArmour(singleArmour);
        }
        public async void SelectedArmour(string armourPiece)
        {
            string url = "https://www.dnd5eapi.co";
            string armourChoice = armourPiece;

            string shorturl = url + armourChoice;

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

            token2 = JsonConvert.DeserializeObject<ArmourSingle.Rootobject>(json, settings);

            tbArmourDetails.Text = $"Armour Name: {token2.name}\n\n";
            tbArmourDetails.Text += $"Armour Size: {token2.armor_category}\n";
            tbArmourDetails.Text += $"Armour Class: {token2.armor_class._base}\n";
            tbArmourDetails.Text += $"Armour Cost: {token2.cost.quantity}{token2.cost.unit}";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAction();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
        }

        private void btnAllSpells_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSetUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Conditions_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            PlayerClasses pcvm = new PlayerClasses();

            pcvm.Show();
        }
        private void Rules_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnMonsters_Click(object sender, RoutedEventArgs e)
        {
            AllMonsters amvm = new AllMonsters();

            amvm.Show();
        }
    }
}
