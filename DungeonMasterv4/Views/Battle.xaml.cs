using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using static DungeonMasterv4.MainWindow;
using System.Net.Http;
using Newtonsoft.Json;
using DungeonMasterv4.Models;

namespace DungeonMasterv4.Views
{
    /// <summary>
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class Battle : Window
    {
        private static readonly Random getrandom = new Random();
        public string singleSpellUrl { get; set; }
        public string monA1 { get; set; }
        public Queue<Tuple<int, int, string, int, int, string, int>> myList = new Queue<Tuple<int, int, string, int, int, string, int>>();
        public Queue<Tuple<int, int, string, int, int, string, int>> myList2 = new Queue<Tuple<int, int, string, int, int, string, int>>();
        Queue<Tuple<string, string, string>> tbupdates = new Queue<Tuple<string, string, string>>();
        public int monHP1 {get; set; }
        public int monHP2 {get; set; }
        public int monHP3 {get; set; }
        public int monHP4 {get; set; }
        public int monHP5 {get; set; }
        public int monHP6 {get; set; }
        public int monHP7 {get; set; }
        public int monHP8 {get; set; }
        public string detailsString { get; set; }
        public string currentHP { get; set; }
        public string information { get; set; }
        string json;
        SpellListAPI.Rootobject token;
        SpellAPI.Rootobject token2;
        public Battle()
        {
            InitializeComponent();
        }
        public Battle(string mon1)
        {
            InitializeComponent();

            this.MouseLeftButtonDown += delegate { this.DragMove(); };

            monA1 = mon1;

            FillSpells();

            BeginBattle();
        }
        public async void FillSpells()
        {
            string url = "https://www.dnd5eapi.co/api/";
            string creatureChoice = "spells/";

            string shorturl = url + creatureChoice;

            var response = new HttpResponseMessage();

            HttpClient apiClient = new HttpClient();

            using (HttpRequestMessage ticketDetails = new HttpRequestMessage())
            {
                ticketDetails.RequestUri = new Uri(shorturl);
                ticketDetails.Method = HttpMethod.Get;
                response = await apiClient.SendAsync(ticketDetails);
            }
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    json = await response.Content.ReadAsStringAsync();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to obtain Service Desk information");
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            token = JsonConvert.DeserializeObject<SpellListAPI.Rootobject>(json, settings);

            foreach (var name in token.results)
            {
                lbSpellList.Items.Add(name.name);
            }
        }
        public void BeginBattle()
        {
            var arrayMonA1 = monA1.Split('\n');
            arrayMonA1 = arrayMonA1.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();

            List<Tuple<int, string, int, int, string, int>> sortingList = new List<Tuple<int, string, int, int, string, int>>();
            
            foreach (var item in arrayMonA1)
            {
                var contentID = item.Split(';');

                if (contentID[0].Length > 0)
                {
                    var name2 = contentID[0];
                    var monAC = int.Parse(contentID[1].Replace("AC: ", ""));
                    var monHP = int.Parse(contentID[2].Replace("HP: ", ""));
                    var details = contentID[3].Replace("þ", "\n");
                    var ini2 = int.Parse(contentID[4]);
                    var changeHp = int.Parse(contentID[2].Replace("HP: ", ""));

                    sortingList.Add(Tuple.Create(ini2, name2, monAC, monHP, details, changeHp));
                }
            }
            sortingList.Sort();
            sortingList.Reverse();
            int i = 1;
            foreach (var item in sortingList)
            {
                var id = i;
                var ini = item.Item1;
                var name = item.Item2;
                var monAC = item.Item3;
                var monHP = item.Item4;
                var details = item.Item5;
                var changeHp = item.Item6;

                myList.Enqueue(Tuple.Create(id, ini, name, monAC, monHP, details, changeHp));
                i++;
            }
            FillBoxes();
        }
        public void FillBoxes()
        {
            int i = 1;
            foreach (var tuple in myList)
            {
                foreach (StackPanel item in spBattleTB.Children.OfType<StackPanel>())
                {
                    foreach (TextBox tb in item.Children.OfType<TextBox>())
                    {
                        if (tb.Name.Contains($"tbAttack{i}") && tb.Text == "")
                        {
                            tb.Text = $"{tuple.Item1} - {tuple.Item3} - AC: {tuple.Item4}";
                        }
                        if (tb.Name.Contains($"tbHP{i}") && tb.Text == "")
                        {
                            tb.Text = $"{tuple.Item5}";
                        }
                        if (tb.Name.Contains($"tbMonD{i}") && tb.Text == "")
                        {
                            tb.Text = $"{tuple.Item6}";
                            break;
                        }
                    }
                }
                i++;
            }
        }
        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            int i = 1;

            tbupdates.Clear();

            foreach (StackPanel item in spBattleTB.Children.OfType<StackPanel>())
            {
                foreach (TextBox tb in item.Children.OfType<TextBox>())
                {
                    if (tb.Name.Contains($"tbAttack{i}") && tb.Text != "")
                    {
                        detailsString = tb.Text;

                        foreach (TextBox box in item.Children.OfType<TextBox>())
                        {
                            if (box.Name.Contains($"tbHP{i}") && box.Text != "")
                            {
                                currentHP = box.Text;
                            }
                            foreach (TextBox detail in item.Children.OfType<TextBox>())
                            {
                                if (detail.Name.Contains($"tbMonD{i}") && detail.Text != "")
                                {
                                    information = detail.Text;
                                }
                            }
                        }
                        tbupdates.Enqueue(Tuple.Create(detailsString, currentHP, information));
                        i++;
                    }
                }
                
            }
            tbupdates = new Queue<Tuple<string, string, string>>(tbupdates.Where(x => x.Item2 != "0"));
            
            foreach (StackPanel item in spBattleTB.Children.OfType<StackPanel>())
            {
                foreach (TextBox tb in item.Children.OfType<TextBox>())
                {
                    tb.Text = "";
                }

            }

            var queueOut = tbupdates.Dequeue();
            tbupdates.Enqueue(queueOut);

            i = 1;

            foreach (var tuple in tbupdates)
            {
                foreach (StackPanel item in spBattleTB.Children.OfType<StackPanel>())
                {
                    foreach (TextBox tb in item.Children.OfType<TextBox>())
                    {
                        if (tb.Name.Contains($"tbAttack{i}"))
                        {
                            tb.Text = tuple.Item1;
                        }
                        if (tb.Name.Contains($"tbHP{i}"))
                        {
                            tb.Text = tuple.Item2;
                        }
                        if (tb.Name.Contains($"tbMonD{i}"))
                        {
                            tb.Text = tuple.Item3;
                        }
                    }
                }
                i++;
            }
        }
        private void btnIni_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;

            tbupdates.Clear();

            foreach (StackPanel item in spBattleTB.Children.OfType<StackPanel>())
            {
                foreach (TextBox tb in item.Children.OfType<TextBox>())
                {
                    if (tb.Name.Contains($"tbAttack{i}") && tb.Text != "")
                    {
                        detailsString = tb.Text;

                        foreach (TextBox box in item.Children.OfType<TextBox>())
                        {
                            if (box.Name.Contains($"tbHP{i}") && box.Text != "")
                            {
                                currentHP = box.Text;

                                foreach (TextBox detail in item.Children.OfType<TextBox>())
                                {
                                    if (detail.Name.Contains($"tbMonD{i}") && detail.Text != "")
                                    {
                                        information = detail.Text.Replace("\n", "þ");
                                        break;
                                    }
                                }
                            }
                        }
                        tbupdates.Enqueue(Tuple.Create(detailsString, currentHP, information));
                        i++;
                    }
                }
            }

            foreach (var person in tbupdates)
            {
                sb.Append($"{person.Item1.Replace(" - ", ";").Replace("AC: ", "")};{person.Item2};{person.Item3}\n");
                i++;
            }

            var result = sb.ToString();
            
            SetUp objWindow = new SetUp(result);

            this.Close();
            objWindow.Show();
        }
        private void tbSpellSrch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempStr = tbSpellSrch.Text.ToLower();

            lbSpellList.Items.Clear();

            foreach (var name in token.results)
            {
                if (name.name.ToLower().Contains(tempStr))
                {
                    lbSpellList.Items.Add(name.name);
                }
            }

            if (String.IsNullOrWhiteSpace(tbSpellSrch.Text))
            {
                foreach (var name in token.results)
                {
                    lbSpellList.Items.Add(name.name);
                }
            }
        }
        private void lbSpellList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tempMon = lbSpellList.SelectedValue.ToString();

            foreach (var name in token.results)
            {
                if (name.name == tempMon)
                {
                    singleSpellUrl = name.url;
                    break;
                }
            }

            SelectedSpell(singleSpellUrl);
        }
        public async void SelectedSpell(string selectedSpell)
        {
            string url = "https://www.dnd5eapi.co";

            string shorturl = url + selectedSpell;

            var response2 = new HttpResponseMessage();

            HttpClient apiClient2 = new HttpClient();

            using (HttpRequestMessage monsterDetails = new HttpRequestMessage())
            {
                monsterDetails.RequestUri = new Uri(shorturl);
                monsterDetails.Method = HttpMethod.Get;
                response2 = await apiClient2.SendAsync(monsterDetails);
            }
            if (response2.IsSuccessStatusCode)
            {
                try
                {
                    json = await response2.Content.ReadAsStringAsync();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to obtain Service Desk information");
                }
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            token2 = JsonConvert.DeserializeObject<SpellAPI.Rootobject>(json, settings);

            tbSpellResult.Text = token2.name + ":\n\n";
            var classNumber = token2.classes.Length;
            for (int i = 0; i < classNumber; i++)
            {
                tbSpellResult.Text += token2.classes[i].name + "\n";
            }
            tbSpellResult.Text += "\n";
            tbSpellResult.Text += "Range: " + token2.range + "\n";
            tbSpellResult.Text += "Level: " + token2.level + "\n";
            tbSpellResult.Text += "Damage Type: " + token2.damage?.damage_type.name + "\n\n";

            var descNumber = token2.desc.Length;
            for (int i = 0; i < descNumber; i++)
            {
                tbSpellResult.Text += token2.desc[i] + "\n";
            }
            var levelNumber = token2.higher_level?.Length;
            for (int i = 0; i < levelNumber; i++)
            {
                tbSpellResult.Text += "\n" + token2.higher_level[i];
            }
        }

        private void btnAttack1_Click(object sender, RoutedEventArgs e)
        {
            tbAtkRoll1.Text = GetRandomNumber(1, 20).ToString();
        }
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
