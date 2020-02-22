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
            try
            {
                if (game.Shops.Count == 0)
                {
                    if (InputTextbox.TextLength == 0)
                        throw new Exception("Shop must have a name!");
                    game.LastUpdated = DateTime.Now;
                    game.AddShop(InputTextbox.Text);
                    Shop1Label.Text = game.Shops[0].ToString();
                    Shop1Button.Text = game.Shops[0].Name;
                    Shop1Label.Visible = true;
                    Shop2Button.Visible = true;
                    Shop2Label.Text = 5000.ToString();
                    InputTextbox.Text = "";
                }
                else
                {
                    game.SelectedShop = 0;
                    UpdateButtons();
                    CheckDoableUpdates();
                }
            }
            catch(Exception ex)
            {
                ExceptionLabel.Text = ex.Message;
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
            var id = InputTextbox.Text;
            try
            {
                game.Load(Convert.ToInt32(InputTextbox.Text));
                LoadButtons();
                UpdateLabels();
            }
            catch (Exception)
            {
                ExceptionLabel.Text = "No game found.";
            }
            InputTextbox.Text = "";
        }

        private void EnhanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                game.EnhanceShop();
                UpdateLabels();
                CheckDoableUpdates();
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
            try
            {
                MoneyLabel.Text = "Money: " + game.Money.ToString();
                ExceptionLabel.Text = "";
                Shop1Label.Text = game.Shops[0].ToString();
                Shop1Label.Visible = true;
                Shop2Label.Visible = true;
                Shop2Label.Text = 5000.ToString();
                if (game.Shops.Count > 1)
                {
                    Shop2Label.Text = game.Shops[1].ToString();
                    Shop3Label.Visible = true;
                    Shop3Label.Text = 10000.ToString();
                }
                if (game.Shops.Count > 2)
                {
                    Shop3Label.Text = game.Shops[2].ToString();
                    Shop4Label.Visible = true;
                    Shop4Label.Text = 20000.ToString();
                }
                if (game.Shops.Count > 3)
                {
                    Shop4Label.Text = game.Shops[3].ToString();
                }
            }
            catch(Exception ex)
            {
                ExceptionLabel.Text = "Game not started.";
            }
        }

        private void LoadButtons()
        {
            Shop1Button.Text = game.Shops[0].Name;
            Shop1Label.Text = game.Shops[0].ToString();
            Shop1Label.Visible = true;
            Shop2Button.Visible = true;
            if (game.Shops.Count > 1)
            {
                Shop2Button.Text = game.Shops[1].Name;
                Shop2Label.Text = game.Shops[1].ToString();
                Shop3Button.Visible = true;
            }
            if (game.Shops.Count > 2)
            {
                Shop3Button.Text = game.Shops[2].Name;
                Shop3Label.Text = game.Shops[2].ToString();
                Shop4Button.Visible = true;
            }
            if (game.Shops.Count > 3)
            {
                Shop4Button.Text = game.Shops[3].Name;
                Shop4Label.Text = game.Shops[3].ToString();
            }

        }

        private void RenovateButton_Click(object sender, EventArgs e)
        {
            try
            {
                game.UpgradeShop();
                UpdateLabels();
                CheckDoableUpdates();
                RefreshButton_Click(sender, e);
            }
            catch(Exception ex)
            {
                ExceptionLabel.Text = ex.Message;
            }
        }

        private void Shop2Button_Click(object sender, EventArgs e)
        {
            if (game.Shops.Count == 1)
            {
                try
                {
                    if (InputTextbox.TextLength == 0)
                        throw new Exception("Shop must have a name!");
                    game.LastUpdated = DateTime.Now;
                    game.AddShop(InputTextbox.Text);
                    Shop2Label.Text = game.Shops[1].ToString();
                    Shop2Button.Text = game.Shops[1].Name;
                    Shop2Label.Visible = true;
                    Shop3Button.Visible = true;
                    Shop3Label.Text = 10000.ToString();
                    UpdateLabels();
                    InputTextbox.Text = "";
                }
                catch(Exception ex)
                {
                    ExceptionLabel.Text = ex.Message;
                }
            }
            else
            {
                game.SelectedShop = 1;
                UpdateButtons();
                CheckDoableUpdates();
            }
        }

        private void Shop3Button_Click(object sender, EventArgs e)
        {
            if (game.Shops.Count == 2)
            {
                try
                {
                    if (InputTextbox.TextLength == 0)
                        throw new Exception("Shop must have a name!");
                    game.LastUpdated = DateTime.Now;
                    game.AddShop(InputTextbox.Text);
                    Shop3Label.Text = game.Shops[2].ToString();
                    Shop3Button.Text = game.Shops[2].Name;
                    Shop3Label.Visible = true;
                    Shop4Button.Visible = true;
                    Shop4Label.Text = 20000.ToString();
                    UpdateLabels();
                    InputTextbox.Text = "";
                }
                catch(Exception ex)
                {
                    ExceptionLabel.Text = ex.Message;
                }
            }
            else
            {
                game.SelectedShop = 2;
                UpdateButtons();
                CheckDoableUpdates();
            }
        }

        private void Shop4Button_Click(object sender, EventArgs e)
        {
            if (game.Shops.Count == 3)
            {
                try
                {
                    if (InputTextbox.TextLength == 0)
                        throw new Exception("Shop must have a name!");
                    game.LastUpdated = DateTime.Now;
                    game.AddShop(InputTextbox.Text);
                    Shop4Label.Text = game.Shops[3].ToString();
                    Shop4Button.Text = game.Shops[3].Name;
                    Shop4Label.Visible = true;
                    UpdateLabels();
                    InputTextbox.Text = "";
                }
                catch (Exception ex)
                {
                    ExceptionLabel.Text = ex.Message;
                }
            }
            else
            {
                game.SelectedShop = 3;
                UpdateButtons();
                CheckDoableUpdates();
            }
        }

        private void CheckDoableUpdates()
        {
            if (game.Shops[game.SelectedShop].UpgradeLevel > 4 || game.Shops[game.SelectedShop].BeingRenovated == true)
                EnhanceButton.Enabled = false;
            else EnhanceButton.Enabled = true;
            if (game.Shops[game.SelectedShop].BaseLevel == ShopLevel.MegaMarket || game.Shops[game.SelectedShop].BeingRenovated == true)
                RenovateButton.Enabled = false;
            else RenovateButton.Enabled = true;
        }
    }
}
