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
            temperatureInfo = new TextBox();
            getTemperatureButton = new Button();
            SuspendLayout();
            // 
            // temperatureInfo
            // 
            temperatureInfo.Location = new Point(234, 40);
            temperatureInfo.Name = "temperatureInfo";
            temperatureInfo.ReadOnly = true;
            temperatureInfo.Size = new Size(125, 27);
            temperatureInfo.TabIndex = 0;
            // 
            // getTemperatureButton
            // 
            getTemperatureButton.Location = new Point(30, 38);
            getTemperatureButton.Name = "getTemperatureButton";
            getTemperatureButton.Size = new Size(182, 29);
            getTemperatureButton.TabIndex = 1;
            getTemperatureButton.Text = "Get Temperature";
            getTemperatureButton.UseVisualStyleBackColor = true;
            getTemperatureButton.Click += getTemperatureButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(getTemperatureButton);
            Controls.Add(temperatureInfo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox temperatureInfo;
        private Button getTemperatureButton;
    }
}
