using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace ShopsMinigame
{
    public partial class GameForm : Form
    {
        private Game.Game game;
        public GameForm()
        {
            InitializeComponent();
            game = new Game.Game();
            MoneyLabel.Text = "Money: " + game.Money.ToString();
        }

        private void Shop1Button_Click(object sender, EventArgs e)
        {
            if (game.Shops.Count == 0)
            {
                game.LastUpdated = DateTime.Now;
                game.AddShop();
                Shop1Label.Text = game.Shops[0].ToString();
                Shop1Button.Text = game.Shops[0].Name;
                Shop1Label.Visible = true;
                Shop2Button.Visible = true;
                Shop2Label.Text = 5000.ToString();
            }
            else
            {
                game.SelectedShop = 0;
                UpdateButtons();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            game.Update(DateTime.Now);
            UpdateLabels();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            game.Save();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            game.Load(1);
            LoadButtons();
            UpdateLabels();
        }

        private void EnhanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                game.EnhanceShop();
                UpdateLabels();
                RefreshButton_Click(sender, e);
            }
            catch(Exception ex)
            {
                ExceptionLabel.Text = ex.Message;
            }
        }

        private void UpdateButtons()
        {
            var i = game.SelectedShop;
            if (game.Shops[i].UpgradeLevel < 5)
            {
                EnhanceButton.Enabled = true;
                EnhanceButton.Text = "Enhance (" + game.Shops[i].CostToUpgrade + ")";
            }
            else EnhanceButton.Enabled = false;
            if (Convert.ToInt32(game.Shops[i].BaseLevel) < 3)
            {
                RenovateButton.Enabled = true;
                RenovateButton.Text = "Renovate (" + game.Shops[i].CostToRenovate + ")";
            }
            else RenovateButton.Enabled = false;
        }

        private void UpdateLabels()
        {
            MoneyLabel.Text = "Money: " + game.Money.ToString();
            ExceptionLabel.Text = "";
            Shop1Label.Text = game.Shops[0].ToString();
            Shop1Label.Visible = true;
            if (game.Shops.Count > 1)
            {
                Shop2Label.Text = game.Shops[1].ToString();
                Shop2Label.Visible = true;
            }
            if (game.Shops.Count > 2)
            {
                Shop3Label.Text = game.Shops[2].ToString();
                Shop3Label.Visible = true;
            }
            if (game.Shops.Count > 3)
            {
                Shop4Label.Text = game.Shops[3].ToString();
                Shop4Label.Visible = true;
            }
        }

        private void LoadButtons()
        {
            Shop1Button.Text = game.Shops[0].Name;
            Shop1Label.Text = game.Shops[0].ToString();
            if (game.Shops.Count > 1)
            {
                Shop2Button.Text = game.Shops[1].Name;
                Shop2Label.Text = game.Shops[1].ToString();
            }
            if (game.Shops.Count > 2)
            {
                Shop3Button.Text = game.Shops[2].Name;
                Shop3Label.Text = game.Shops[2].ToString();
            }
            if (game.Shops.Count > 3)
            {
                Shop4Button.Text = game.Shops[3].Name;
                Shop4Label.Text = game.Shops[4].ToString();
            }

        }

        private void RenovateButton_Click(object sender, EventArgs e)
        {
            try
            {
                game.UpgradeShop();
                UpdateLabels();
                RefreshButton_Click(sender, e);
            }
            catch(Exception ex)
            {
                ExceptionLabel.Text = ex.Message;
            }
        }
    }
}
