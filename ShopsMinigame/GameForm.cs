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
            MoneyLabel.Text = "Money: " + game.Money.ToString();
            ExceptionLabel.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            game.Save();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            game.Load(1);
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
            Shop1Label.Text = game.Shops[0].ToString();
        }
    }
}
