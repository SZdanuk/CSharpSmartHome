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
            getTempButton = new Button();
            temperatureOutput = new TextBox();
            SuspendLayout();
            // 
            // getTempButton
            // 
            getTempButton.Location = new Point(304, 182);
            getTempButton.Name = "getTempButton";
            getTempButton.Size = new Size(94, 29);
            getTempButton.TabIndex = 0;
            getTempButton.Text = "Get temp";
            getTempButton.UseVisualStyleBackColor = true;
            getTempButton.Click += getTempButton_Click;
            // 
            // temperatureOutput
            // 
            temperatureOutput.Location = new Point(463, 184);
            temperatureOutput.Name = "temperatureOutput";
            temperatureOutput.ReadOnly = true;
            temperatureOutput.Size = new Size(125, 27);
            temperatureOutput.TabIndex = 1;
            temperatureOutput.Text = "No data";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(temperatureOutput);
            Controls.Add(getTempButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button getTempButton;
        private TextBox temperatureOutput;
    }
}