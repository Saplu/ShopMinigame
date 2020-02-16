namespace ShopsMinigame
{
    partial class GameForm
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
            this.Shop1Button = new System.Windows.Forms.Button();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.EnhanceButton = new System.Windows.Forms.Button();
            this.RenovateButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.Shop1Label = new System.Windows.Forms.Label();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.Shop2Button = new System.Windows.Forms.Button();
            this.Shop3Button = new System.Windows.Forms.Button();
            this.Shop4Button = new System.Windows.Forms.Button();
            this.Shop3Label = new System.Windows.Forms.Label();
            this.Shop2Label = new System.Windows.Forms.Label();
            this.Shop4Label = new System.Windows.Forms.Label();
            this.InputTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Shop1Button
            // 
            this.Shop1Button.Location = new System.Drawing.Point(113, 71);
            this.Shop1Button.Name = "Shop1Button";
            this.Shop1Button.Size = new System.Drawing.Size(75, 23);
            this.Shop1Button.TabIndex = 0;
            this.Shop1Button.Text = "Start";
            this.Shop1Button.UseVisualStyleBackColor = true;
            this.Shop1Button.Click += new System.EventHandler(this.Shop1Button_Click);
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.Location = new System.Drawing.Point(113, 390);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(0, 13);
            this.MoneyLabel.TabIndex = 1;
            // 
            // EnhanceButton
            // 
            this.EnhanceButton.Location = new System.Drawing.Point(520, 71);
            this.EnhanceButton.Name = "EnhanceButton";
            this.EnhanceButton.Size = new System.Drawing.Size(120, 23);
            this.EnhanceButton.TabIndex = 2;
            this.EnhanceButton.Text = "Enhance";
            this.EnhanceButton.UseVisualStyleBackColor = true;
            this.EnhanceButton.Click += new System.EventHandler(this.EnhanceButton_Click);
            // 
            // RenovateButton
            // 
            this.RenovateButton.Location = new System.Drawing.Point(520, 129);
            this.RenovateButton.Name = "RenovateButton";
            this.RenovateButton.Size = new System.Drawing.Size(120, 23);
            this.RenovateButton.TabIndex = 3;
            this.RenovateButton.Text = "Renovate";
            this.RenovateButton.UseVisualStyleBackColor = true;
            this.RenovateButton.Click += new System.EventHandler(this.RenovateButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(520, 223);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(120, 23);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(520, 314);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(520, 367);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(120, 23);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load Game";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Shop1Label
            // 
            this.Shop1Label.AutoSize = true;
            this.Shop1Label.Location = new System.Drawing.Point(113, 110);
            this.Shop1Label.Name = "Shop1Label";
            this.Shop1Label.Size = new System.Drawing.Size(0, 13);
            this.Shop1Label.TabIndex = 7;
            this.Shop1Label.Visible = false;
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Location = new System.Drawing.Point(113, 432);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(0, 13);
            this.ExceptionLabel.TabIndex = 8;
            // 
            // Shop2Button
            // 
            this.Shop2Button.Location = new System.Drawing.Point(261, 70);
            this.Shop2Button.Name = "Shop2Button";
            this.Shop2Button.Size = new System.Drawing.Size(75, 23);
            this.Shop2Button.TabIndex = 9;
            this.Shop2Button.Text = "New Shop";
            this.Shop2Button.UseVisualStyleBackColor = true;
            this.Shop2Button.Visible = false;
            this.Shop2Button.Click += new System.EventHandler(this.Shop2Button_Click);
            // 
            // Shop3Button
            // 
            this.Shop3Button.Location = new System.Drawing.Point(113, 208);
            this.Shop3Button.Name = "Shop3Button";
            this.Shop3Button.Size = new System.Drawing.Size(75, 23);
            this.Shop3Button.TabIndex = 10;
            this.Shop3Button.Text = "New Shop";
            this.Shop3Button.UseVisualStyleBackColor = true;
            this.Shop3Button.Visible = false;
            this.Shop3Button.Click += new System.EventHandler(this.Shop3Button_Click);
            // 
            // Shop4Button
            // 
            this.Shop4Button.Location = new System.Drawing.Point(261, 208);
            this.Shop4Button.Name = "Shop4Button";
            this.Shop4Button.Size = new System.Drawing.Size(75, 23);
            this.Shop4Button.TabIndex = 11;
            this.Shop4Button.Text = "New Shop";
            this.Shop4Button.UseVisualStyleBackColor = true;
            this.Shop4Button.Visible = false;
            this.Shop4Button.Click += new System.EventHandler(this.Shop4Button_Click);
            // 
            // Shop3Label
            // 
            this.Shop3Label.AutoSize = true;
            this.Shop3Label.Location = new System.Drawing.Point(113, 238);
            this.Shop3Label.Name = "Shop3Label";
            this.Shop3Label.Size = new System.Drawing.Size(0, 13);
            this.Shop3Label.TabIndex = 14;
            // 
            // Shop2Label
            // 
            this.Shop2Label.AutoSize = true;
            this.Shop2Label.Location = new System.Drawing.Point(261, 109);
            this.Shop2Label.Name = "Shop2Label";
            this.Shop2Label.Size = new System.Drawing.Size(0, 13);
            this.Shop2Label.TabIndex = 15;
            // 
            // Shop4Label
            // 
            this.Shop4Label.AutoSize = true;
            this.Shop4Label.Location = new System.Drawing.Point(261, 238);
            this.Shop4Label.Name = "Shop4Label";
            this.Shop4Label.Size = new System.Drawing.Size(0, 13);
            this.Shop4Label.TabIndex = 16;
            // 
            // InputTextbox
            // 
            this.InputTextbox.Location = new System.Drawing.Point(520, 407);
            this.InputTextbox.Name = "InputTextbox";
            this.InputTextbox.Size = new System.Drawing.Size(120, 20);
            this.InputTextbox.TabIndex = 17;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InputTextbox);
            this.Controls.Add(this.Shop4Label);
            this.Controls.Add(this.Shop2Label);
            this.Controls.Add(this.Shop3Label);
            this.Controls.Add(this.Shop4Button);
            this.Controls.Add(this.Shop3Button);
            this.Controls.Add(this.Shop2Button);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.Shop1Label);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.RenovateButton);
            this.Controls.Add(this.EnhanceButton);
            this.Controls.Add(this.MoneyLabel);
            this.Controls.Add(this.Shop1Button);
            this.Name = "GameForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Shop1Button;
        private System.Windows.Forms.Label MoneyLabel;
        private System.Windows.Forms.Button EnhanceButton;
        private System.Windows.Forms.Button RenovateButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label Shop1Label;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.Button Shop2Button;
        private System.Windows.Forms.Button Shop3Button;
        private System.Windows.Forms.Button Shop4Button;
        private System.Windows.Forms.Label Shop3Label;
        private System.Windows.Forms.Label Shop2Label;
        private System.Windows.Forms.Label Shop4Label;
        private System.Windows.Forms.TextBox InputTextbox;
    }
}

