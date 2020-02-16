using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        private double _money;
        private double _moneyPerSecond;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public int ID { get; set; }
        public int SelectedShop { get; set; } = 0;
        public double Money { get => Convert.ToInt32(_money); set => _money = value; }
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public Game()
        {
            Money = 0;
            ID = GetNewId(false);
        }

        public void AddShop(string name)
        {
            var cost = CalculateNewShopCost();
            if (_money < cost)
                throw new Exception("Not enough money.");
            var newid = GetNewId(true);
            Shops.Add(new Shop(name, newid, ID));
            CalculateMoneyPerSecond();
        }

        public void Update(DateTime time)
        {
            var timespan = time - LastUpdated;
            var money = timespan.TotalMilliseconds * _moneyPerSecond / (double)1000;
            _money += money;
            LastUpdated = time;
            CheckShopUpgradeTimes(timespan);
            CalculateMoney();
        }

        public void Save()
        {
            var dtlGame = ConvertToDTLGame();
            DAL.DAL dal = new DAL.DAL();
            dal.Save(dtlGame);
        }

        public void Load(int gameid)
        {
            var dal = new DAL.DAL();
            var dtlGame = dal.Read(gameid);
            ConvertDTLToGame(dtlGame);
            CalculateMoney();
            SelectedShop = 0;
            LastUpdated = DateTime.Now;
        }

        public void EnhanceShop()
        {
            if (_money >= Shops[SelectedShop].CostToUpgrade)
            {
                _money -= Shops[SelectedShop].CostToUpgrade;
                Shops[SelectedShop].Enhance();
                CalculateMoney();
            }
            else throw new Exception("Not enough money.");
        }

        public void UpgradeShop()
        {
            if (_money >= Shops[SelectedShop].CostToRenovate)
            {
                _money -= Shops[SelectedShop].CostToRenovate;
                Shops[SelectedShop].Renovate();
                CalculateMoney();
            }
            else throw new Exception("Not enough money.");
        }

        private void CalculateMoneyPerSecond()
        {
            _moneyPerSecond = 0;

            var money = Shops.Where(s => s.BeingRenovated == false)
                             .Select(s => (double)s.IncomePerMinute / 60);
            money.ToList().ForEach(s => _moneyPerSecond += s);
        }

        private void CheckShopUpgradeTimes(TimeSpan timeSpan)
        {
            foreach(var shop in Shops)
            {
                if (shop.BeingRenovated)
                {
                    shop.MillisecondsUntilReady -= Convert.ToInt32(timeSpan.TotalMilliseconds);
                    if (shop.MillisecondsUntilReady <= 0)
                    {
                        shop.BeingRenovated = false;
                        shop.MillisecondsUntilReady = 0;
                        CalculateMoneyPerSecond();
                    }
                }
            }
        }

        private DTL.DTLShop ConvertToDTLShop(Shop shop) =>
            new DTL.DTLShop(shop.Id, ID, shop.UpgradeLevel, Convert.ToInt32(shop.BaseLevel), shop.IncomePerMinute,
                shop.CostToUpgrade, shop.CostToRenovate, shop.MillisecondsUntilReady, shop.Name, shop.BeingRenovated);

        private Shop ConvertToShop(DTL.DTLShop dtl) =>
            new Shop(dtl.Name, dtl.Id, dtl.GameId, dtl.BaseLevel, dtl.UpgradeLevel, dtl.IncomePerMinute,
                dtl.CostToUpgrade, dtl.CostToRenovate, dtl.BeingRenovated, dtl.MillisecondsUntilReady);

        private void ConvertDTLToGame(DTL.DTLGame dtlGame)
        {
            this.ID = dtlGame.Id;
            this.LastUpdated = dtlGame.LastUpdated;
            this.Money = dtlGame.Money;
            this.Shops = new List<Shop>();
            dtlGame.DTLShops.ForEach(s => Shops.Add(ConvertToShop(s)));
        }

        private DTL.DTLGame ConvertToDTLGame()
        {
            var dtlShopList = new List<DTL.DTLShop>();
            Shops.ForEach(s => dtlShopList.Add(ConvertToDTLShop(s)));
            return new DTL.DTLGame(this.ID, Convert.ToInt32(this.Money), this.LastUpdated, dtlShopList);
        }

        private void CalculateMoney()
        {
            var timePassed = (DateTime.Now - LastUpdated).TotalMilliseconds;
            Shops.ForEach(s => SingleShopCalculation(timePassed, s));
            CalculateMoneyPerSecond();
        }

        private void SingleShopCalculation(double milliseconds, Shop shop)
        {
            var time = -1 * (shop.MillisecondsUntilReady - milliseconds);
            var value = time / 60000 * shop.IncomePerMinute;
            shop.MillisecondsUntilReady = Math.Max(0, Convert.ToInt32(shop.MillisecondsUntilReady - milliseconds));
            if (value > 0)
                Money += value;
        }

        private int GetNewId(bool shop)
        {
            var dal = new DAL.DAL();
            return dal.GetLastShopId(shop) + 1;
        }

        private int CalculateNewShopCost()
        {
            switch(Shops.Count())
            {
                case 0: return 0;
                case 1: return 5000;
                case 2: return 10000;
                case 3: return 20000;
                default: throw new Exception("Not possible anymore.");
            }
        }
    }
}
