using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for DiceRollsView.xaml
    /// </summary>
    public partial class DiceRollsView : Window
    {
        private static readonly Random getrandom = new Random();

        public static System.Action CloseAction { get; set; }
        public DiceRollsView()
        {
            InitializeComponent();

            if (CloseAction == null)
                CloseAction = new Action(this.Close);

            this.MouseLeftButtonDown += delegate { this.DragMove(); };
        }
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
        // D100 Dice Rolling
        private void btnMinusD100_Click(object sender, RoutedEventArgs e)
        {
            if (tbD100Number.Text == "" | tbD100Number.Text == null)
            {
                tbD100Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD100Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD100Number.Text = "0";
                }
                else
                {
                    tbD100Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD100_Click(object sender, RoutedEventArgs e)
        {
            if (tbD100Number.Text == "" | tbD100Number.Text == null)
            {
                tbD100Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD100Number.Text);
                var outNumber = firstNumber + 1;
                tbD100Number.Text = outNumber.ToString();
            }
        }
        private void btnRollD100_Click(object sender, RoutedEventArgs e)
        {
            tbTotalRolledD100.Text = "";
            tbIndividRolledD100.Text = "";
            if (tbD100Number.Text == "" | tbD100Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD100Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD100.Text += int.Parse(GetRandomNumber(1, 100).ToString()) + ", ";
            }
            tbIndividRolledD100.Text = tbIndividRolledD100.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD100.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD100.Text = totalNumber.ToString();
        }
        // D20 Dice Rolling
        private void btnMinusD20_Click(object sender, RoutedEventArgs e)
        {
            if (tbD20Number.Text == "" | tbD20Number.Text == null)
            {
                tbD20Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD20Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD20Number.Text = "0";
                }
                else
                {
                    tbD20Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD20_Click(object sender, RoutedEventArgs e)
        {
            if (tbD20Number.Text == "" | tbD20Number.Text == null)
            {
                tbD20Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD20Number.Text);
                var outNumber = firstNumber + 1;
                tbD20Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD20_Click(object sender, RoutedEventArgs e)
        {
            tbTotalRolledD20.Text = "";
            tbIndividRolledD20.Text = "";
            if (tbD20Number.Text == "" | tbD20Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD20Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD20.Text += int.Parse(GetRandomNumber(1, 20).ToString()) + ", ";
            }
            tbIndividRolledD20.Text = tbIndividRolledD20.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD20.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD20.Text = totalNumber.ToString();
        }
        // D12 Dice Rolling
        private void btnMinusD12_Click(object sender, RoutedEventArgs e)
        {
            if (tbD12Number.Text == "" | tbD12Number.Text == null)
            {
                tbD12Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD12Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD12Number.Text = "0";
                }
                else
                {
                    tbD12Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD12_Click(object sender, RoutedEventArgs e)
        {
            if (tbD12Number.Text == "" | tbD12Number.Text == null)
            {
                tbD12Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD12Number.Text);
                var outNumber = firstNumber + 1;
                tbD12Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD12_Click(object sender, RoutedEventArgs e)
        {
            tbTotalRolledD12.Text = "";
            tbIndividRolledD12.Text = "";
            if (tbD12Number.Text == "" | tbD12Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD12Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD12.Text += int.Parse(GetRandomNumber(1, 12).ToString()) + ", ";
            }
            tbIndividRolledD12.Text = tbIndividRolledD12.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD12.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD12.Text = totalNumber.ToString();
        }
        // D10 Dice Rolling
        private void btnMinusD10_Click(object sender, RoutedEventArgs e)
        {
            if (tbD10Number.Text == "" | tbD10Number.Text == null)
            {
                tbD10Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD10Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD10Number.Text = "0";
                }
                else
                {
                    tbD10Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD10_Click(object sender, RoutedEventArgs e)
        {
            if (tbD10Number.Text == "" | tbD10Number.Text == null)
            {
                tbD10Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD10Number.Text);
                var outNumber = firstNumber + 1;
                tbD10Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD10_Click(object sender, RoutedEventArgs e)
        {
            tbTotalRolledD10.Text = "";
            tbIndividRolledD10.Text = "";
            if (tbD10Number.Text == "" | tbD10Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD10Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD10.Text += int.Parse(GetRandomNumber(1, 10).ToString()) + ", ";
            }
            tbIndividRolledD10.Text = tbIndividRolledD10.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD10.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD10.Text = totalNumber.ToString();
        }

        // D8 Dice Rolling

        private void btnMinusD8_Click(object sender, RoutedEventArgs e)
        {
            if (tbD8Number.Text == "" | tbD8Number.Text == null)
            {
                tbD8Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD8Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD8Number.Text = "0";
                }
                else
                {
                    tbD8Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD8_Click(object sender, RoutedEventArgs e)
        {
            if (tbD8Number.Text == "" | tbD8Number.Text == null)
            {
                tbD8Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD8Number.Text);
                var outNumber = firstNumber + 1;
                tbD8Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD8_Click(object sender, RoutedEventArgs e)
        {
            tbTotalRolledD8.Text = "";
            tbIndividRolledD8.Text = "";
            if (tbD8Number.Text == "" | tbD8Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD8Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD8.Text += int.Parse(GetRandomNumber(1, 8).ToString()) + ", ";
            }
            tbIndividRolledD8.Text = tbIndividRolledD8.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD8.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD8.Text = totalNumber.ToString();
        }
        // D6 Dice Rolling
        private void btnMinusD6_Click(object sender, RoutedEventArgs e)
        {
            if (tbD6Number.Text == "" | tbD6Number.Text == null)
            {
                tbD6Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD6Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD6Number.Text = "0";
                }
                else
                {
                    tbD6Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD6_Click(object sender, RoutedEventArgs e)
        {
            if (tbD6Number.Text == "" | tbD6Number.Text == null)
            {
                tbD6Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD6Number.Text);
                var outNumber = firstNumber + 1;
                tbD6Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD6_Click(object sender, RoutedEventArgs e)
        {

            tbTotalRolledD6.Text = "";
            tbIndividRolledD6.Text = "";
            if (tbD6Number.Text == "" | tbD6Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD6Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD6.Text += int.Parse(GetRandomNumber(1, 6).ToString()) + ", ";
            }
            tbIndividRolledD6.Text = tbIndividRolledD6.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD6.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD6.Text = totalNumber.ToString();
        }

        
        // D4 Dice Rolling
        private void btnMinusD4_Click(object sender, RoutedEventArgs e)
        {
            if (tbD4Number.Text == "" | tbD4Number.Text == null)
            {
                tbD4Number.Text = "0";
            }
            else
            {
                var firstNumber = int.Parse(tbD4Number.Text);
                var outNumber = firstNumber - 1;
                if (outNumber <= 0)
                {
                    tbD4Number.Text = "0";
                }
                else
                {
                    tbD4Number.Text = outNumber.ToString();
                }
            }
        }

        private void btnPlusD4_Click(object sender, RoutedEventArgs e)
        {
            if (tbD4Number.Text == "" | tbD4Number.Text == null)
            {
                tbD4Number.Text = "1";
            }
            else
            {
                var firstNumber = int.Parse(tbD4Number.Text);
                var outNumber = firstNumber + 1;
                tbD4Number.Text = outNumber.ToString();
            }
        }

        private void btnRollD4_Click(object sender, RoutedEventArgs e)
        {

            tbTotalRolledD4.Text = "";
            tbIndividRolledD4.Text = "";
            if (tbD4Number.Text == "" | tbD4Number.Text == null)
            {
                return;
            }
            var totalToRoll = int.Parse(tbD4Number.Text);


            for (int i = 0; i < totalToRoll; i++)
            {
                tbIndividRolledD4.Text += int.Parse(GetRandomNumber(1, 4).ToString()) + ", ";
            }
            tbIndividRolledD4.Text = tbIndividRolledD4.Text.Trim().Trim(',');
            var splitNumbers = tbIndividRolledD4.Text.Split(',');

            var totalNumber = 0;

            foreach (var item in splitNumbers)
            {
                if (item != "" && item != " ")
                {
                    var singleNumber = int.Parse(item);
                    totalNumber = totalNumber + singleNumber;
                }
            }

            tbTotalRolledD4.Text = totalNumber.ToString();
        }

        private void btnClearDice_Click(object sender, RoutedEventArgs e)
        {
            tbD100Number.Text = "";
            tbD20Number.Text = "";
            tbD12Number.Text = "";
            tbD10Number.Text = "";
            tbD8Number.Text = "";
            tbD6Number.Text = "";
            tbD4Number.Text = "";

            tbIndividRolledD100.Text = "";
            tbIndividRolledD20.Text = "";
            tbIndividRolledD12.Text = "";
            tbIndividRolledD10.Text = "";
            tbIndividRolledD8.Text = "";
            tbIndividRolledD6.Text = "";
            tbIndividRolledD4.Text = "";

            tbTotalRolledD100.Text = "";
            tbTotalRolledD20.Text = "";
            tbTotalRolledD12.Text = "";
            tbTotalRolledD10.Text = "";
            tbTotalRolledD8.Text = "";
            tbTotalRolledD6.Text = "";
            tbTotalRolledD4.Text = "";
        }
    }
}
