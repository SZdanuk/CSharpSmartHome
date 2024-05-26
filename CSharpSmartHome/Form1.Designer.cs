namespace CSharpSmartHome
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
            button1 = new Button();
            roomTemperature = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(29, 32);
            button1.Name = "button1";
            button1.Size = new Size(134, 37);
            button1.TabIndex = 0;
            button1.Text = "Get temperature";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // roomTemperature
            // 
            roomTemperature.AccessibleRole = AccessibleRole.None;
            roomTemperature.Location = new Point(169, 37);
            roomTemperature.Name = "roomTemperature";
            roomTemperature.ReadOnly = true;
            roomTemperature.Size = new Size(125, 27);
            roomTemperature.TabIndex = 1;
            roomTemperature.Text = "No data";
            roomTemperature.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(roomTemperature);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox roomTemperature;
    }
}