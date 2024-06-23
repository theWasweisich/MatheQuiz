using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class SettingsForm : Form
    {

        public int? MaximumTime { get; set; }
        public string? ExersiceTypes { get; set; }
        public int? ZahlenraumValue { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
            this.BringToFront();
            this.Activate();
        }


        public void LoadSettings()
        {
            Trace.TraceInformation("Loading Settings!");
            string[] typen = Properties.Settings.Default.Calc_Types.Split(",");
            if (typen.Contains("Addition")) { checkAddition.Checked = true; }
            if (typen.Contains("Subtraction")) { checkSubtraction.Checked = true; }
            if (typen.Contains("Multiplication")) { checkMultiplication.Checked = true; }
            if (typen.Contains("Division")) { checkDivision.Checked = true; }

            maxTime.Value = Properties.Settings.Default.MaxTime;

            if (Properties.Settings.Default.Zahlenraum == 100)
            {
                zahlenraum.SelectedIndex = 1;
            }
            else
            {
                zahlenraum.SelectedIndex = 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maxTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            switch (zahlenraum.Text)
            {
                case "1 - 10":
                    this.ZahlenraumValue = 10;
                    break;
                case "1 - 100":
                    this.ZahlenraumValue = 100;
                    break;
                default:
                    throw new Exception("Re-Check Zahlenraum values on SettingsForm");
            }
            this.MaximumTime = ((int)maxTime.Value);
            string[] ExerciseTypes_List = new string[4];

            if (checkAddition.Checked) { ExerciseTypes_List[0] = "Addition"; }
            if (checkSubtraction.Checked) { ExerciseTypes_List[1] = "Subtraction"; }
            if (checkMultiplication.Checked) { ExerciseTypes_List[2] = "Multiplication"; }
            if (checkDivision.Checked) { ExerciseTypes_List[3] = "Division"; }

            this.ExersiceTypes = string.Join(",", ExerciseTypes_List);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void zahlenraum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkSubtraction_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
