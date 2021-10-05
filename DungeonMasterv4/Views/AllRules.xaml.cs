using DungeonMasterv4.Models;
using DungeonMasterv4.Models.Rules;
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
    /// Interaction logic for AllRules.xaml
    /// </summary>
    public partial class AllRules : Window
    {
        public static System.Action CloseAction { get; set; }

        public string ruleSectionChoice { get; set; }
        public string ruleSubChoice { get; set; }

        string jsonSecction;
        string jsonSub;
        string jsonRule;

        RulesListAPI.Rootobject sectionList;
        AdventuringListAPI.Rootobject subList;
        RulesDetailsAPI.Rootobject rulesDetails;

        public AllRules()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillSectionList();
        }
        #region Logic
        public async void FillSectionList()
        {
            string url = "https://www.dnd5eapi.co";
            string rulesSection = "/api/rules";

            string shorturl = url + rulesSection;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(shorturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    jsonSecction = await response.Content.ReadAsStringAsync();
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            sectionList = JsonConvert.DeserializeObject<RulesListAPI.Rootobject>(jsonSecction, settings);

            foreach (var sec in sectionList.results)
            {
                lbSectionList.Items.Add(sec.name);
            }
        }
        private void lbSectionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbSectionList.SelectedValue.ToString();

            foreach (var name in sectionList.results)
            {
                if (name.name == tempCat)
                {
                    ruleSectionChoice = name.url;
                    break;
                }
            }
            SelectedSubsection(ruleSectionChoice);
        }
        public async void SelectedSubsection(string subsection)
        {
            lbSubList.Items.Clear();

            string url = "https://www.dnd5eapi.co";
            string shorturl = url + subsection;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(shorturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    jsonSub = await response.Content.ReadAsStringAsync();
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            subList = JsonConvert.DeserializeObject<AdventuringListAPI.Rootobject>(jsonSub, settings);

            foreach (var sub in subList.subsections)
            {
                lbSubList.Items.Add(sub.name);
            }
        }
        private void lbSubList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbSubList.SelectedValue.ToString();

            foreach (var name in subList.subsections)
            {
                if (name.name == tempCat)
                {
                    ruleSubChoice = name.url;
                    break;
                }
            }
            SelectedRule(ruleSubChoice);
        }
        public async void SelectedRule(string ruleChoice)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + ruleChoice;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(shorturl))
            {
                if (response.IsSuccessStatusCode)
                {
                    jsonSub = await response.Content.ReadAsStringAsync();
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            rulesDetails = JsonConvert.DeserializeObject<RulesDetailsAPI.Rootobject>(jsonSub, settings);

            tbRulesDetails.Text = rulesDetails.name + "\n\n";

            tbRulesDetails.Text += rulesDetails.desc;
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

        private void Conditions_Click(object sender, RoutedEventArgs e)
        {
            Conditions cvm = new Conditions();

            cvm.Show();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {

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
