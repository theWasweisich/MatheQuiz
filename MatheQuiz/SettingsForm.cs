﻿using System;
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
        public string[]? ExersiceTypes { get; set; }
        public int? ZahlenraumValue { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        public void LoadSettings()
        {
            Trace.TraceInformation("Loading Settings!");
            string[] typen = Properties.Settings.Default.Calc_Types.Split(",");
            if (typen.Contains("Addition")) { exercise_type.SetItemChecked(0, true); }
            if (typen.Contains("Subtraction")) { exercise_type.SetItemChecked(1, true); }
            if (typen.Contains("Multiplication")) { exercise_type.SetItemChecked(2, true); }
            if (typen.Contains("Division")) { exercise_type.SetItemChecked(3, true); }

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
                case "1-10":
                    this.ZahlenraumValue = 10;
                    break;
                case "1-100":
                    this.ZahlenraumValue = 100;
                    break;
                default:
                    this.ZahlenraumValue = -1;
                    break;
            }
            this.MaximumTime = ((int)maxTime.Value);
            this.ExersiceTypes = exercise_type.Text.Split(",");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}