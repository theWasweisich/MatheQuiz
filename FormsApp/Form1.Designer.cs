namespace FormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timeRemaining = new Label();
            time_remaining_label = new Label();
            toggle_exercise = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            timer1 = new System.Windows.Forms.Timer(components);
            calc_first = new Label();
            calc_operator = new Label();
            calc_second = new Label();
            calc_equals = new Label();
            calc_result = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            LanguageSelector = new ComboBox();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calc_result).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // timeRemaining
            // 
            resources.ApplyResources(timeRemaining, "timeRemaining");
            timeRemaining.Name = "timeRemaining";
            // 
            // time_remaining_label
            // 
            resources.ApplyResources(time_remaining_label, "time_remaining_label");
            time_remaining_label.Name = "time_remaining_label";
            // 
            // toggle_exercise
            // 
            resources.ApplyResources(toggle_exercise, "toggle_exercise");
            toggle_exercise.Cursor = Cursors.Hand;
            toggle_exercise.Name = "toggle_exercise";
            toggle_exercise.UseVisualStyleBackColor = true;
            toggle_exercise.Click += QuizResult_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripDropDownButton1 });
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(toolStripStatusLabel2, "toolStripStatusLabel2");
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(toolStripDropDownButton1, "toolStripDropDownButton1");
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Click += OptionsButton;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += Timer_Tick;
            // 
            // calc_first
            // 
            resources.ApplyResources(calc_first, "calc_first");
            calc_first.Name = "calc_first";
            calc_first.Click += calc_first_Click;
            // 
            // calc_operator
            // 
            resources.ApplyResources(calc_operator, "calc_operator");
            calc_operator.Name = "calc_operator";
            calc_operator.Click += calc_operator_Click;
            // 
            // calc_second
            // 
            resources.ApplyResources(calc_second, "calc_second");
            calc_second.Name = "calc_second";
            calc_second.Click += calc_second_Click;
            // 
            // calc_equals
            // 
            resources.ApplyResources(calc_equals, "calc_equals");
            calc_equals.Name = "calc_equals";
            calc_equals.Click += calc_equals_Click;
            // 
            // calc_result
            // 
            calc_result.BackColor = SystemColors.ControlLight;
            resources.ApplyResources(calc_result, "calc_result");
            calc_result.Name = "calc_result";
            calc_result.ValueChanged += calc_result_ValueChanged;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlDark;
            resources.ApplyResources(label1, "label1");
            label1.FlatStyle = FlatStyle.Flat;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // LanguageSelector
            // 
            LanguageSelector.FormattingEnabled = true;
            LanguageSelector.Items.AddRange(new object[] { resources.GetString("LanguageSelector.Items"), resources.GetString("LanguageSelector.Items1") });
            resources.ApplyResources(LanguageSelector, "LanguageSelector");
            LanguageSelector.Name = "LanguageSelector";
            LanguageSelector.SelectedIndexChanged += LanguageSelector_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(time_remaining_label);
            splitContainer1.Panel1.Controls.Add(timeRemaining);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(LanguageSelector);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(calc_result);
            panel2.Controls.Add(calc_second);
            panel2.Controls.Add(calc_operator);
            panel2.Controls.Add(calc_first);
            panel2.Controls.Add(calc_equals);
            panel2.Name = "panel2";
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // panel4
            // 
            panel4.Controls.Add(toggle_exercise);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calc_result).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeRemaining;
        private Label time_remaining_label;
        private Button toggle_exercise;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private Label calc_first;
        private Label calc_operator;
        private Label calc_second;
        private Label calc_equals;
        private NumericUpDown calc_result;
        private Label label1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private Label label2;
        private ComboBox LanguageSelector;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}