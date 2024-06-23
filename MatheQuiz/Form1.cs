using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using MatheQuiz.Properties;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public bool exercise_running = false;

        readonly Random randomizer = new();

        public string[] exercise_types = [];

        public int timeElapsed = 0;     // bereits verstrichene Zeit in Sekunden
        public int maxTime = 60;        // Zeit für eine Aufgabe in Sekunden
        public int zahlenraum = 0;      // Der Zahlenraum, in dem gerechnet werden soll.
                                        // Der Zahlenraum ist entweder 10 (1-10) oder 100 (1-100)

        public int expectedResult;

        ResourceManager? resManager;
        CultureInfo? culture;

        public Form1()
        {
            InitializeComponent(); // Muss vor sämtlichem Code ausgeführt werden
            calc_result.Enabled = false;
            InitSettings();
            InitLocalisation();
            LanguageSelector.SelectedIndex = 1;
        }

        /// <summary>
        /// A helper function that might help future additions questionmark
        /// </summary>
        public static void ForceRestart()
        {
            Application.Restart();
            Environment.Exit(0);
        }

        /// <summary>
        /// Loads the currently applied settings into memory
        /// </summary>
        public void InitSettings()
        {
            exercise_types = Properties.Settings.Default.Calc_Types.Split(",");
            maxTime = Properties.Settings.Default.MaxTime;
            zahlenraum = Properties.Settings.Default.Zahlenraum;
            Debug.WriteLineIf(zahlenraum < 10, "Zahlenraum ist nicht korrekt!");
            Debug.WriteLineIf(zahlenraum < 10, $"Zahlenraum: {zahlenraum}");
            return;
        }

        /// <summary>
        /// Initializes the resourceManager and the current culture
        /// </summary>
        public void InitLocalisation()
        {
            resManager = new ResourceManager("MatheQuiz.Properties.Resources", typeof(Form1).Assembly);

            culture = CultureInfo.CurrentCulture;
            Update_Localisation("en-DE");
        }

        public ResourceManager GetCustomResourceManager()
        {
            if (resManager == null) { throw new NullReferenceException("The resource manager has not yet been initialized!"); }
            return resManager;
        }

        public void ChangeLocalisation(string langCode)
        {
            culture = new CultureInfo(langCode);
            Update_Localisation("en-DE");
        }

        /// <summary>
        /// Updates the current Localisation of hard-coded elements
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if the resourceManager is not yet initialized</exception>
        public void Update_Localisation(string language)
        {
            resManager = GetCustomResourceManager();

            culture = new CultureInfo(language);

            string? exercise_running_label = resManager.GetString("exercise_running", culture);
            string? exercise_stopped = resManager.GetString("exercise_stopped", culture);
            string? stop_exercise = resManager.GetString("stop_exercise", culture);
            string? start = resManager.GetString("start", culture);
            string? options = resManager.GetString("options", culture);
            string? rounding_note = resManager.GetString("rounding_note", culture);

            exercise_running_label ??= "Error";
            exercise_stopped ??= "Error";
            stop_exercise ??= "Error";
            start ??= "Error";
            options ??= "Error";
            rounding_note ??= "Error";

            time_remaining_label.Visible = false;
            timeRemaining.Visible = false;

            optionsItem.Text = options;
            toolStripRoundingInfo.Text = rounding_note;

            if (exercise_running)
            {
                toolStripStatusLabel1.Text = exercise_running_label;
                toggle_exercise.Text = stop_exercise;
            }
            else
            {
                toolStripStatusLabel1.Text = exercise_stopped;
                toggle_exercise.Text = start;
            }

        }

        /// <summary>
        /// Function called by UI-Element to start or stop the current quiz
        /// </summary>
        /// <exception cref="NullReferenceException">Resources have not been initialized</exception>
        private void ToggleExerciseClick(object sender, EventArgs e)
        {
            resManager = GetCustomResourceManager();
            if (exercise_running)
            {
                EndQuizz();
                // toggle_exercise.Text = "Start exercise";
                toolStripStatusLabel1.Text = resManager.GetString("exercise_stopped", culture);
                toolStripStatusLabel1.ForeColor = Color.Gray;
                exercise_running = false;
            }
            else
            {
                CreateQuizz();
                toggle_exercise.Text = resManager.GetString("stop_exercise", culture);
                toolStripStatusLabel1.Text = resManager.GetString("exercise_running", culture);
                toolStripStatusLabel1.ForeColor = Color.Green;
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
                time_remaining_label.Visible = false;
                timeRemaining.Visible = false;
            }
            else
            {
                time_remaining_label.Visible = true;
                timeRemaining.Visible = true;
                time_remaining_label.Text = "Time left:";
                timeRemaining.Text = remaining.ToString();
            }
        }

        /// <summary>
        /// Resets the timer
        /// </summary>
        private void ResetTimer()
        {
            timer1.Stop();
            timeElapsed = 0;
        }

        /// <summary>
        /// Called by the timer object
        /// </summary>
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

        /// <summary>
        /// Creates a random quiz
        /// </summary>
        /// <exception cref="Exception">It was not possible to chose an operator</exception>
        private void CreateQuizz()
        {
            if (zahlenraum <= 0)
            {
                zahlenraum = 10;
            }

            string operator_ = "";
            string[] possible_operators = Properties.Settings.Default.Calc_Types.Split(",");

            int iterations = 0;
            while (operator_ == "")
            {
                if (iterations >= 20)
                {
                    throw new Exception("Ok, you gotta be kiddin' me!");
                }
                operator_ = possible_operators[randomizer.Next(possible_operators.Length)];
                iterations++;
            }


            int sum_first = randomizer.Next(zahlenraum) + 1;
            int sum_second = randomizer.Next(zahlenraum) + 1;
            int result;
            switch (operator_)
            {
                case "Addition":
                    calc_operator.Text = "+";
                    result = sum_first + sum_second;
                    break;
                case "Subtraction":
                    calc_operator.Text = "-";
                    result = sum_first - sum_second;
                    break;
                case "Multiplication":
                    calc_operator.Text = "*";
                    result = sum_first * sum_second;
                    break;
                case "Division":
                    calc_operator.Text = "/";
                    try
                    {
                        result = sum_first / sum_second;
                    }
                    catch (DivideByZeroException)
                    {
                        ResetQuiz();
                        return;
                    }
                    break;
                default:
                    throw new Exception("Operator Value does not match one of the Operators");
            }

            expectedResult = result;
            calc_first.Text = sum_first.ToString();
            calc_second.Text = sum_second.ToString();

            calc_result.Enabled = true;

            calc_result.Focus();

            this.BringToFront();
            this.Activate();

            DisplayTime(true, maxTime);
            timer1.Start();
        }

        /// <summary>
        /// Checks if the given result matches the expected result
        /// </summary>
        /// <returns>true if the answer is correct, false otherwise</returns>
        private bool CheckAnswer()
        {
            exercise_running = false;
            calc_result.Enabled = false;
            // Return true, if the answer is correct, else return false
            return calc_result.Value == expectedResult;
        }

        /// <summary>
        /// 
        /// </summary>
        async private void EndQuizz()
        {
            resManager = GetCustomResourceManager();
            timer1.Stop();
            DisplayTime(false);
            bool correct = CheckAnswer();
            int wait_seconds = 2;
            if (correct)
            {
                toggle_exercise.Text = resManager.GetString("correct", culture);
                toggle_exercise.BackColor = Color.Green;
                await Task.Delay(wait_seconds * 1000);
                toggle_exercise.Text = resManager.GetString("start", culture);
                toggle_exercise.BackColor = SystemColors.Control;
            }
            else
            {
                toggle_exercise.Text = resManager.GetString("incorrect", culture);
                toggle_exercise.BackColor = Color.Red;
                await Task.Delay(wait_seconds * 1000);
                toggle_exercise.Text = resManager.GetString("start", culture);
                toggle_exercise.BackColor = SystemColors.Control;
            }
            ResetQuiz();
        }

        private void ResetQuiz()
        {
            exercise_running = false;
            ResetTimer();
            calc_first.Text = "?";
            calc_second.Text = "?";
            calc_operator.Text = "?";
            calc_result.Value = 0;
        }

        private void OptionsButton(object sender, EventArgs e)
        {
            SettingsForm prompt = new();
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
                string[] types = new string[4];

                if (prompt.ExersiceTypes == null)
                {
                    throw new Exception("Variable is null: ExersiceTypes");
                }
                if (prompt.ExersiceTypes.Length == 0)
                {
                    types[0] = "Addition";
                }
                else
                {
                    types = prompt.ExersiceTypes.Split(",");
                }

                Zahlenraum ??= 10;
                MaxTime ??= 60;

                Properties.Settings.Default.MaxTime = MaxTime.Value;
                Properties.Settings.Default.Zahlenraum = Zahlenraum.Value;
                string toSettings = string.Join(",", types);
                Properties.Settings.Default.Calc_Types = toSettings;

                Debug.WriteLine($"Types: {types}");
                Properties.Settings.Default.Save();

                InitSettings();
            }
        }

        private void UpdateLocale(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            ComponentResourceManager resources = new(typeof(Form1));
            resources.ApplyResources(this, "$this");
            ApplyResources(resources, this.Controls);
        }

        private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                ApplyResources(resources, ctl.Controls);
            }
        }

        private void LanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] german_key = ["German (Deutsch)", "Deutsch (German)"];
            if (german_key.Contains(LanguageSelector.SelectedItem.ToString()))
            {
                Update_Localisation("de");
                UpdateLocale("de");
            }
            else
            {
                Update_Localisation("en-DE");
                UpdateLocale("en-DE");
            }
        }

        private void CalcResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EndQuizz();
            }
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e) { OptionsButton(sender, e); }

        private void calc_result_FocusEnter(object sender, EventArgs e)
        {
            calc_result.ResetText();
        }
    }
}