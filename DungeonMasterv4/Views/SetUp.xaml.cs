using DungeonMasterv4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static DungeonMasterv4.MainWindow;

namespace DungeonMasterv4.Views
{
    /// <summary>
    /// Interaction logic for SetUp.xaml
    /// </summary>
    public partial class SetUp : Window
    {
        public string singleMonsterUrl { get; set; }
        string json;
        MonsterListAPI.Rootobject token;
        MonsterAPI.Rootobject token2;

        List<Monster> monster = new List<Monster>();

        List<BattleMonster> battleMonster = new List<BattleMonster>();

        private static readonly Random getrandom = new Random();

        public static System.Action CloseAction { get; set; }

        #region Logic
        public SetUp()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            ReadData();
        }
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
        public SetUp(string mon1)
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            ReadData();
            FillCharacterBox(mon1);
        }
        private void ReadData()
        {
            FillListBox();
        }
        public async void FillListBox()
        {
            string url = "https://www.dnd5eapi.co/";
            string creatureChoice = "api/monsters/";

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

            token = JsonConvert.DeserializeObject<MonsterListAPI.Rootobject>(json, settings);

            foreach (var name in token.results)
            {
                lbMonster1.Items.Add(name.name);
            }
        }
        public void FillCharacterBox(string characters)
        {
            var charArray = characters.Split('\n');
            charArray = charArray.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();

            foreach (var charac in charArray)
            {
                if (charac.Length > 1)
                {
                    var output = charac.Split(';');

                    if (output[4] != "Player Character")
                    {
                        if (tbSelectedMonster1.Text == "")
                        {
                            tbSelectedMonster1.Text = $"{output[1]}; AC: {output[2]}; HP: {output[3]}";
                            tbMondetails1.Text = $"{output[4].Replace("þ", "\n")}";
                        }
                        else if (tbSelectedMonster2.Text == "")
                        {
                            tbSelectedMonster2.Text = $"{output[1]}; AC: {output[2]}; HP: {output[3]}";
                            tbMondetails2.Text = $"{output[4].Replace("þ", "\n")}";
                        }
                        else if (tbSelectedMonster3.Text == "")
                        {
                            tbSelectedMonster3.Text = $"{output[1]}; AC: {output[2]}; HP: {output[3]}";
                            tbMondetails3.Text = $"{output[4].Replace("þ", "\n")}";
                        }
                        else if (tbSelectedMonster4.Text == "")
                        {
                            tbSelectedMonster4.Text = $"{output[1]}; AC: {output[2]}; HP: {output[3]}";
                            tbMondetails4.Text = $"{output[4].Replace("þ", "\n")}";
                        }
                        else if (tbSelectedMonster5.Text == "")
                        {
                            tbSelectedMonster5.Text = $"{output[1]}; AC: {output[2]}; HP: {output[3]}";
                            tbMondetails5.Text = $"{output[4].Replace("þ", "\n")}";
                        }
                    }
                    else
                    {
                        if (tbSelectedPC1.Text == "")
                        {
                            tbSelectedPC1.Text = output[1];
                            tbPCAC1.Text = output[2];
                            tbPCHP1.Text = output[3];
                        }
                        else if (tbSelectedPC2.Text == "")
                        {
                            tbSelectedPC2.Text = output[1];
                            tbPCAC2.Text = output[2];
                            tbPCHP2.Text = output[3];
                        }
                        else if (tbSelectedPC3.Text == "")
                        {
                            tbSelectedPC3.Text = output[1];
                            tbPCAC3.Text = output[2];
                            tbPCHP3.Text = output[3];
                        }
                    }
                }
            }
        }
        private void tbList1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbList1.Text.ToLower();

            lbMonster1.Items.Clear();

            foreach (var name in token.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbMonster1.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbList1.Text))
            {
                foreach (var name in token.results)
                {
                    lbMonster1.Items.Add(name.name);
                }
            }
        }
        private void lbMonster1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempMon = lbMonster1.SelectedValue.ToString();

            foreach (var name in token.results)
            {
                if (name.name == tempMon)
                {
                    singleMonsterUrl = name.index;
                    break;
                }
            }

            

            SelectedCreature(singleMonsterUrl);
        }
        public async void SelectedCreature(string creature)
        {
            string url = "https://www.dnd5eapi.co/";
            string creatureChoice = creature;

            string shorturl = url + "api/monsters/" + creatureChoice;

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

            token2 = JsonConvert.DeserializeObject<MonsterAPI.Rootobject>(json, settings);

            if (token2 != null)
            {
                if (tbSelectedMonster1.Text == "")
                {
                    tbSelectedMonster1.Text = $"{token2.name}; AC: {token2.armor_class}; HP: {token2.hit_points}";
                    if (token2?.special_abilities != null)
                    {
                        foreach (var item in token2.special_abilities)
                        {
                            tbMondetails1.Text = $"{item.desc}\n\n";
                        }
                    }
                    foreach (var damage in token2.actions)
                    {
                        tbMondetails1.Text += $"{damage.desc}\n";
                    }
                    tbInitiative1.Text = GetRandomNumber(1, 20).ToString();
                }
                else if (tbSelectedMonster2.Text == "")
                {
                    tbSelectedMonster2.Text = $"{token2.name}; AC: {token2.armor_class}; HP: {token2.hit_points}";
                    if (token2?.special_abilities != null)
                    {
                        foreach (var item in token2.special_abilities)
                        {
                            tbMondetails2.Text = $"{item.desc}\n\n";
                        }
                    }
                    foreach (var damage in token2.actions)
                    {
                        tbMondetails2.Text += $"{damage.desc}\n";
                    }
                    tbInitiative2.Text = GetRandomNumber(1, 20).ToString();
                }
                else if (tbSelectedMonster3.Text == "")
                {
                    tbSelectedMonster3.Text = $"{token2.name}; AC: {token2.armor_class}; HP: {token2.hit_points}";
                    if (token2?.special_abilities != null)
                    {
                        foreach (var item in token2.special_abilities)
                        {
                            tbMondetails3.Text = $"{item.desc}\n\n";
                        }
                    }
                    foreach (var damage in token2.actions)
                    {
                        tbMondetails3.Text += $"{damage.desc}\n";
                    }
                    tbInitiative3.Text = GetRandomNumber(1, 20).ToString();
                }
                else if (tbSelectedMonster4.Text == "")
                {
                    tbSelectedMonster4.Text = $"{token2.name}; AC: {token2.armor_class}; HP: {token2.hit_points}";
                    if (token2?.special_abilities != null)
                    {
                        foreach (var item in token2.special_abilities)
                        {
                            tbMondetails4.Text = $"{item.desc}\n\n";
                        }
                    }
                    foreach (var damage in token2.actions)
                    {
                        tbMondetails4.Text += $"{damage.desc}\n";
                    }
                    tbInitiative4.Text = GetRandomNumber(1, 20).ToString();
                }
                else if (tbSelectedMonster5.Text == "")
                {
                    tbSelectedMonster5.Text = $"{token2.name}; AC: {token2.armor_class}; HP: {token2.hit_points}";
                    if (token2?.special_abilities != null)
                    {
                        foreach (var item in token2.special_abilities)
                        {
                            tbMondetails5.Text = $"{item.desc}\n\n";
                        }
                    }
                    foreach (var damage in token2.actions)
                    {
                        tbMondetails5.Text += $"{damage.desc}\n";
                    }
                    tbInitiative5.Text = GetRandomNumber(1, 20).ToString();
                }
            }
        }
        private void btnBattle_Click(object sender, RoutedEventArgs e)
        {
            #region Empty Checks
            if (tbSelectedMonster1.Text != "" && tbInitiative1.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedMonster1.Text}");
                return;
            }
            if (tbSelectedMonster2.Text != "" && tbInitiative2.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedMonster2.Text}.");
                return;
            }
            if (tbSelectedMonster3.Text != "" && tbInitiative3.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedMonster3.Text}.");
                return;
            }
            if (tbSelectedMonster4.Text != "" && tbInitiative4.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedMonster4.Text}.");
                return;
            }
            if (tbSelectedMonster5.Text != "" && tbInitiative5.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedMonster5.Text}.");
                return;
            }
            if (tbSelectedPC1.Text != "" && tbInitiative6.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedPC1.Text}.");
                return;
            }
            if (tbSelectedPC2.Text != "" && tbInitiative7.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedPC2.Text}.");
                return;
            }
            if (tbSelectedPC3.Text != "" && tbInitiative8.Text == "")
            {
                MessageBox.Show($"You must enter an initiative value for {tbSelectedPC3.Text}.");
                return;
            }
            #endregion

            StringBuilder sb = new StringBuilder();

            if (tbSelectedMonster1.Text != "")
            {
                sb.Append(tbSelectedMonster1.Text + ";" + tbMondetails1.Text.Replace("\n", "þ") + ";" + tbInitiative1.Text + '\n');
            }
            if (tbSelectedMonster2.Text != "")
            {
                sb.Append(tbSelectedMonster2.Text + ";" + tbMondetails2.Text.Replace("\n", "þ") + ";" + tbInitiative2.Text + '\n');
            }
            if (tbSelectedMonster3.Text != "")
            {
                sb.Append(tbSelectedMonster3.Text + ";" + tbMondetails3.Text.Replace("\n", "þ") + ";" + tbInitiative3.Text + '\n');
            }
            if (tbSelectedMonster4.Text != "")
            {
                sb.Append(tbSelectedMonster4.Text + ";" + tbMondetails4.Text.Replace("\n", "þ") + ";" + tbInitiative4.Text + '\n');
            }
            if (tbSelectedMonster5.Text != "")
            {
                sb.Append(tbSelectedMonster5.Text + ";" + tbMondetails5.Text.Replace("\n", "þ") + ";" + tbInitiative5.Text + '\n');
            }
            if (tbSelectedPC1.Text != "")
            {
                sb.Append(tbSelectedPC1.Text + ";" + $"AC: {tbPCAC1.Text};" + $"HP: {tbPCHP1.Text};" + "Player Character;" + tbInitiative6.Text + '\n');
            }
            if (tbSelectedPC2.Text != "")
            {
                sb.Append(tbSelectedPC2.Text + ";" + $"AC: {tbPCAC2.Text};" + $"HP: {tbPCHP2.Text};" + "Player Character;" + tbInitiative7.Text + '\n');
            }
            if (tbSelectedPC3.Text != "")
            {
                sb.Append(tbSelectedPC3.Text + ";" + $"AC: {tbPCAC3.Text};" + $"HP: {tbPCHP3.Text};" + "Player Character;" + tbInitiative8.Text + '\n');
            }

            string mon1 = sb.ToString();

            var objBattle = new Battle(mon1);

            this.Close();
            objBattle.ShowDialog();
        }
        private void btnCleared_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster1.Text = "";
            tbSelectedMonster2.Text = "";
            tbSelectedMonster3.Text = "";
            tbSelectedMonster4.Text = "";
            tbSelectedMonster5.Text = "";

            tbMondetails1.Text = "";
            tbMondetails2.Text = "";
            tbMondetails3.Text = "";
            tbMondetails4.Text = "";
            tbMondetails5.Text = "";

            tbInitiative1.Text = "";
            tbInitiative2.Text = "";
            tbInitiative3.Text = "";
            tbInitiative4.Text = "";
            tbInitiative5.Text = "";
        }
        private void btnClearedPC_Click(object sender, RoutedEventArgs e)
        {
            tbInitiative6.Text = "";
            tbInitiative7.Text = "";
            tbInitiative8.Text = "";

            tbPCAC1.Text = "";
            tbPCAC2.Text = "";
            tbPCAC3.Text = "";

            tbPCHP1.Text = "";
            tbPCHP2.Text = "";
            tbPCHP3.Text = "";
        }
        private void btnClear1_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster1.Text = "";

            tbMondetails1.Text = "";

            tbInitiative1.Text = "";
        }
        private void btnClear2_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster2.Text = "";

            tbMondetails2.Text = "";

            tbInitiative2.Text = "";
        }
        private void btnClear3_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster3.Text = "";

            tbMondetails3.Text = "";

            tbInitiative3.Text = "";
        }
        private void btnClear4_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster4.Text = "";

            tbMondetails4.Text = "";

            tbInitiative4.Text = "";
        }
        private void btnClear5_Click(object sender, RoutedEventArgs e)
        {
            tbSelectedMonster5.Text = "";

            tbMondetails5.Text = "";

            tbInitiative5.Text = "";
        }
        #endregion

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            CloseAction();
        }
        private void btnSetUp_Click(object sender, RoutedEventArgs e)
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
        public void btnAllSpells_Click(object sender, RoutedEventArgs e)
        {
            AllSpells asvm = new AllSpells();

            asvm.Show();
        }
        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment eqvm = new Equipment();

            eqvm.Show();
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
    }
}
