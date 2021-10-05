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
    /// Interaction logic for Conditions.xaml
    /// </summary>
    public partial class Conditions : Window
    {
        public static System.Action CloseAction { get; set; }

        public string conditionChoice { get; set; }
        string json;
        ConditionsListAPI.Rootobject conditionsList;
        ConditionsAPI.Rootobject conditionsDetails;

        public Conditions()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillConditionsList();
        }
        #region Logic
        public async void FillConditionsList()
        {
            string url = "https://www.dnd5eapi.co";
            string conditionCategories = "/api/conditions";

            string shorturl = url + conditionCategories;

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

            conditionsList = JsonConvert.DeserializeObject<ConditionsListAPI.Rootobject>(json, settings);

            foreach (var con in conditionsList.results)
            {
                lbConditionList.Items.Add(con.name);
            }
        }
        private void tbConditionSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbConditionSearch.Text.ToLower();

            lbConditionList.Items.Clear();

            foreach (var name in conditionsList.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbConditionList.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbConditionSearch.Text))
            {
                foreach (var name in conditionsList.results)
                {
                    lbConditionList.Items.Add(name.name);
                }
            }
        }

        private void lbConditionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbConditionList.SelectedValue.ToString();

            foreach (var name in conditionsList.results)
            {
                if (name.name == tempCat)
                {
                    conditionChoice = name.url;
                    break;
                }
            }
            SelectedCondition(conditionChoice);
        }
        public async void SelectedCondition(string condChoice)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + condChoice;

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

            conditionsDetails = JsonConvert.DeserializeObject<ConditionsAPI.Rootobject>(json, settings);

            tbConditionDetails.Text = conditionsDetails.name + "\n\n";

            if (conditionsDetails?.desc != null)
            {
                foreach (var desc in conditionsDetails?.desc)
                {
                    tbConditionDetails.Text += desc + "\n";
                }
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
            AllSpells asvm = new AllSpells();

            asvm.Show();
        }

        private void btnConditions_Click(object sender, RoutedEventArgs e)
        {

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
