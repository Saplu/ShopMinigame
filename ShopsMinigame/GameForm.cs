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
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            game.Update(DateTime.Now);
            MoneyLabel.Text = "Money: " + game.Money.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            game.Save();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            game.Load(1);
        }
    }
}
