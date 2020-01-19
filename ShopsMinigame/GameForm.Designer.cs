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
            this.EnhanceButton.Size = new System.Drawing.Size(75, 23);
            this.EnhanceButton.TabIndex = 2;
            this.EnhanceButton.Text = "Enhance";
            this.EnhanceButton.UseVisualStyleBackColor = true;
            // 
            // RenovateButton
            // 
            this.RenovateButton.Location = new System.Drawing.Point(520, 129);
            this.RenovateButton.Name = "RenovateButton";
            this.RenovateButton.Size = new System.Drawing.Size(75, 23);
            this.RenovateButton.TabIndex = 3;
            this.RenovateButton.Text = "Renovate";
            this.RenovateButton.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(520, 223);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(520, 314);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

