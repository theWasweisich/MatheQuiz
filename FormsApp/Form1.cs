using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public bool exercise_running = false;

        Random randomizer = new Random();

        public string[] exercise_types = [];

        public int timeElapsed = 0;     // bereits verstrichene Zeit in Sekunden
        public int maxTime = 60;        // Zeit für eine Aufgabe in Sekunden
        public int zahlenraum = 0;      // Der Zahlenraum, in dem gerechnet werden soll.
                                        // Der Zahlenraum ist entweder 10 (1-10) oder 100 (1-100)

        public int expectedResult;

        public Form1()
        {
            InitializeComponent();
            calc_result.Enabled = false;
            LanguageSelector.SelectedIndex = 0;
            InitSettings();
        }

        public void InitSettings()
        {
            exercise_types = Properties.Settings.Default.Calc_Types.Split(",");
            maxTime = Properties.Settings.Default.MaxTime;
            zahlenraum = Properties.Settings.Default.Zahlenraum;
            Debug.WriteLineIf(zahlenraum < 10, "Zahlenraum ist nicht korrekt!");
            Debug.WriteLineIf(zahlenraum < 10, $"Zahlenraum: {zahlenraum}");
            return;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick_1(object sender, EventArgs e)
        {

        }

        private void QuizResult_Click(object sender, EventArgs e)
        {
            if (exercise_running)
            {
                EndQuizz();
                toggle_exercise.Text = "Start exercise";
                toolStripStatusLabel1.Text = "Exercise stopped";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Gray;
                exercise_running = false;
            }
            else
            {
                CreateQuizz();
                toggle_exercise.Text = "End Exercise";
                toolStripStatusLabel1.Text = "Exercise running";
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.Green;
                exercise_running = true;
            }
        }

        /// <summary>
        /// Displayes the remaining time, or hides the time remaining labels
        /// </summary>
        /// <param name="visible">If the labels should be visible in the first place</param>
        /// <param name="remaining">The time remaining in seconds</param>
        private void DisplayTime(bool visible, int remaining = 0)
        {
            if (!visible || remaining <= 0)
            {
                time_remaining_label.Text = string.Empty;
                timeRemaining.Text = string.Empty;
            }
            else
            {
                time_remaining_label.Text = "Time left:";
                timeRemaining.Text = remaining.ToString();
            }
        }

        private void ResetTimer()
        {
            timer1.Stop();
            timeElapsed = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeElapsed >= maxTime)
            {
                timer1.Stop();
                EndQuizz();
            }
            timeElapsed += 1;

            DisplayTime(true, (maxTime - timeElapsed));
        }

        private void CreateQuizz()
        {
            int sum_first = randomizer.Next(zahlenraum);
            int sum_second = randomizer.Next(zahlenraum);
            int result = sum_first + sum_second;

            expectedResult = result;
            calc_first.Text = sum_first.ToString();
            calc_second.Text = sum_second.ToString();

            calc_result.Enabled = true;

            calc_result.Focus();

            timer1.Start();
        }

        private bool CheckAnswer()
        {
            exercise_running = false;
            calc_result.Enabled = false;
            // Return true, if the answer is correct, else return false
            return calc_result.Value == expectedResult;
        }

        async private void EndQuizz()
        {
            timer1.Stop();
            DisplayTime(false);
            bool correct = CheckAnswer();
            Color previous = toggle_exercise.BackColor;
            int wait_seconds = 2;
            if (correct)
            {
                toggle_exercise.Text = "Correct!";
                toggle_exercise.BackColor = Color.Green;
                await Task.Delay(wait_seconds * 1000);
                toggle_exercise.Text = "Start";
            }
            else
            {
                toggle_exercise.Text = "Incorrect!";
                toggle_exercise.BackColor = Color.Red;
                await Task.Delay(wait_seconds * 1000);
                toggle_exercise.Text = "Start";
            }
            toggle_exercise.BackColor = previous;
            ResetQuiz();
        }

        private void ResetQuiz()
        {
            ResetTimer();
            calc_first.Text = "?";
            calc_second.Text = "?";
            calc_result.Value = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OptionsButton(object sender, EventArgs e)
        {
            SettingsForm prompt = new SettingsForm();
            var result = prompt.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                prompt.Close();
            }
            else if (result == DialogResult.OK)
            {
                // How do I get the Values of Form2?
                int? Zahlenraum = prompt.ZahlenraumValue;
                int? MaxTime = prompt.MaximumTime;
                string[]? types = prompt.ExersiceTypes;

                if (Zahlenraum == null) { Zahlenraum = 10; }
                if (MaxTime == null) { MaxTime = 60; }
                if (types == null) { types = Array.Empty<string>(); }

                Properties.Settings.Default.MaxTime = MaxTime.Value;
                Properties.Settings.Default.Zahlenraum = Zahlenraum.Value;
                Properties.Settings.Default.Calc_Types = string.Join(",", types);

                Properties.Settings.Default.Save();

                InitSettings();
            }
        }

        /// <summary>
        /// Changes the current Program Language
        /// </summary>
        /// <param name="language">The Language Code</param>
        private void ChangeLanguage(string language)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                resources.ApplyResources(c, c.Name, new CultureInfo(language));
            }
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageSelector.SelectedItem.ToString() == "German")
            {
                ChangeLanguage("de");
            }
            else
            {
                ChangeLanguage("en-DE");
            }
        }

        private void calc_first_Click(object sender, EventArgs e)
        {

        }

        private void calc_operator_Click(object sender, EventArgs e)
        {
        }

        private void calc_second_Click(object sender, EventArgs e)
        {
        }

        private void calc_equals_Click(object sender, EventArgs e)
        {
        }

        private void calc_result_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}