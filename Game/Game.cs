﻿using System;
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
        public DateTime LastUpdated { get; set; }
        public int ID { get; set; }
        public double Money { get => Convert.ToInt32(_money); set => _money = value; }
        public List<Shop> Shops { get; set; }

        public Game()
        {
            Money = 0;
            ID = 1;
            Shops = new List<Shop>();
            LastUpdated = DateTime.Now;
        }

        public void AddShop()
        {
            Shops.Add(new Shop("TestShop", 1));
            CalculateMoneyPerSecond();
        }

        public void Update(DateTime time)
        {
            var timespan = time - LastUpdated;
            var money = timespan.TotalMilliseconds * _moneyPerSecond / (double)1000;
            _money += money;
            LastUpdated = time;
            CheckShopUpgradeTimes(timespan);
        }

        public void Save()
        {
            var dtlShops = new List<DTL.DTLShop>();
            Shops.ForEach(s => dtlShops.Add(ConvertToDTLShop(s)));
            DAL.DAL dal = new DAL.DAL();

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
                        CalculateMoneyPerSecond();
                    }
                }
            }
        }

        private DTL.DTLShop ConvertToDTLShop(Shop shop)
        {
            var dtlShop = new DTL.DTLShop(shop.Id, ID, shop.UpgradeLevel, Convert.ToInt32(shop.BaseLevel), shop.IncomePerMinute,
                shop.CostToUpgrade, shop.CostToRenovate, shop.MillisecondsUntilReady, shop.Name, shop.BeingRenovated);
            return dtlShop;
        }
    }
}