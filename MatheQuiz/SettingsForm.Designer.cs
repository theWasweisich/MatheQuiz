namespace FormsApp
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            label1 = new Label();
            label2 = new Label();
            maxTime = new NumericUpDown();
            label3 = new Label();
            exercise_type = new CheckedListBox();
            label4 = new Label();
            label5 = new Label();
            zahlenraum = new ListBox();
            save_button = new Button();
            QuitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)maxTime).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // maxTime
            // 
            maxTime.BackColor = Color.FromArgb(255, 192, 192);
            resources.ApplyResources(maxTime, "maxTime");
            maxTime.Name = "maxTime";
            maxTime.Value = new decimal(new int[] { 60, 0, 0, 0 });
            maxTime.ValueChanged += maxTime_ValueChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            label3.Click += label3_Click;
            // 
            // exercise_type
            // 
            exercise_type.BackColor = Color.FromArgb(255, 192, 192);
            resources.ApplyResources(exercise_type, "exercise_type");
            exercise_type.FormattingEnabled = true;
            exercise_type.Items.AddRange(new object[] { resources.GetString("exercise_type.Items"), resources.GetString("exercise_type.Items1"), resources.GetString("exercise_type.Items2"), resources.GetString("exercise_type.Items3") });
            exercise_type.Name = "exercise_type";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // zahlenraum
            // 
            zahlenraum.FormattingEnabled = true;
            resources.ApplyResources(zahlenraum, "zahlenraum");
            zahlenraum.Items.AddRange(new object[] { resources.GetString("zahlenraum.Items"), resources.GetString("zahlenraum.Items1") });
            zahlenraum.Name = "zahlenraum";
            // 
            // save_button
            // 
            resources.ApplyResources(save_button, "save_button");
            save_button.Name = "save_button";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            // 
            // QuitButton
            // 
            resources.ApplyResources(QuitButton, "QuitButton");
            QuitButton.Name = "QuitButton";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            Controls.Add(QuitButton);
            Controls.Add(save_button);
            Controls.Add(zahlenraum);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(exercise_type);
            Controls.Add(label3);
            Controls.Add(maxTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsForm";
            TopMost = true;
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)maxTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown maxTime;
        private Label label3;
        private CheckedListBox exercise_type;
        private Label label4;
        private Label label5;
        private ListBox zahlenraum;
        private Button save_button;
        private Button QuitButton;
    }
}