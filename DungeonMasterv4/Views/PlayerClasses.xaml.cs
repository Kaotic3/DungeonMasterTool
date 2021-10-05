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
    /// Interaction logic for PlayerClasses.xaml
    /// </summary>
    public partial class PlayerClasses : Window
    {
        public static System.Action CloseAction { get; set; }

        public string classChoice { get; set; }
        string json;
        ClassListAPI.Rootobject classList;
        ClassDetailsAPI.Rootobject classDetails;

        public PlayerClasses()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            FillClassList();
        }
        public async void FillClassList()
        {
            string url = "https://www.dnd5eapi.co";
            string classesToList = "/api/classes";

            string shorturl = url + classesToList;

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

            classList = JsonConvert.DeserializeObject<ClassListAPI.Rootobject>(json, settings);

            foreach (var className in classList.results)
            {
                lbClassList.Items.Add(className.name);
            }
        }
        private void lbClassList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempCat = lbClassList.SelectedValue.ToString();

            foreach (var name in classList.results)
            {
                if (name.name == tempCat)
                {
                    classChoice = name.url;
                    break;
                }
            }
            SelectedClass(classChoice);
        }
        public async void SelectedClass(string classChoices)
        {
            string url = "https://www.dnd5eapi.co";
            string shorturl = url + classChoices;

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

            classDetails = JsonConvert.DeserializeObject<ClassDetailsAPI.Rootobject>(json, settings);

            tbClassDetails.Text = classDetails.name + "\n\n";

            tbClassDetails.Text += $"Hit Dice: {classDetails.hit_die}\n";

            if (classDetails?.spellcasting?.info != null)
            {
                foreach (var desc in classDetails?.spellcasting?.info)
                {
                    tbClassDetails.Text += "\n";
                    foreach (var words in desc.desc)
                    {
                        tbClassDetails.Text += words + "\n";
                    }
                }
                tbClassDetails.Text += "\n";
            }
            if (classDetails?.proficiency_choices != null)
            {
                tbClassDetails.Text += "Proficiency Choices: ";
                foreach (var prof in classDetails?.proficiency_choices)
                {
                    tbClassDetails.Text += $"Pick: {prof.choose}\n";
                    tbClassDetails.Text += $"From: ";
                    foreach (var choices in prof.from)
                    {
                        tbClassDetails.Text += $"{choices.name}, ";
                    }
                    tbClassDetails.Text += "\n";
                }
            }
            if (classDetails?.proficiencies != null)
            {
                tbClassDetails.Text += "Proficiencies Known: ";
                foreach (var known in classDetails?.proficiencies)
                {
                    tbClassDetails.Text += $"{known.name}, ";
                }
            }
            
            if (classDetails?.subclasses != null)
            {
                tbClassDetails.Text += "\n";
                foreach (var sub in classDetails?.subclasses)
                {
                    tbClassDetails.Text += "Subclasses: ";
                    tbClassDetails.Text += sub.name + "\n";
                }
            }
        }

        #region Menu Items
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
            Equipment aevm = new Equipment();

            aevm.Show();
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
