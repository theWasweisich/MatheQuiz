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
            label4 = new Label();
            label5 = new Label();
            zahlenraum = new ListBox();
            save_button = new Button();
            QuitButton = new Button();
            checkAddition = new CheckBox();
            checkSubtraction = new CheckBox();
            checkMultiplication = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            checkDivision = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)maxTime).BeginInit();
            flowLayoutPanel1.SuspendLayout();
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
            zahlenraum.SelectedIndexChanged += zahlenraum_SelectedIndexChanged;
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
            // checkAddition
            // 
            resources.ApplyResources(checkAddition, "checkAddition");
            checkAddition.Name = "checkAddition";
            checkAddition.UseVisualStyleBackColor = true;
            checkAddition.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkSubtraction
            // 
            resources.ApplyResources(checkSubtraction, "checkSubtraction");
            checkSubtraction.Name = "checkSubtraction";
            checkSubtraction.UseVisualStyleBackColor = true;
            checkSubtraction.CheckedChanged += checkSubtraction_CheckedChanged;
            // 
            // checkMultiplication
            // 
            resources.ApplyResources(checkMultiplication, "checkMultiplication");
            checkMultiplication.Name = "checkMultiplication";
            checkMultiplication.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(checkAddition);
            flowLayoutPanel1.Controls.Add(checkSubtraction);
            flowLayoutPanel1.Controls.Add(checkMultiplication);
            flowLayoutPanel1.Controls.Add(checkDivision);
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // checkDivision
            // 
            resources.ApplyResources(checkDivision, "checkDivision");
            checkDivision.Name = "checkDivision";
            checkDivision.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(QuitButton);
            Controls.Add(save_button);
            Controls.Add(zahlenraum);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(maxTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsForm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)maxTime).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown maxTime;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox zahlenraum;
        private Button save_button;
        private Button QuitButton;
        private CheckBox checkAddition;
        private CheckBox checkSubtraction;
        private CheckBox checkMultiplication;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox checkDivision;
        private TableLayoutPanel tableLayoutPanel1;
    }
}