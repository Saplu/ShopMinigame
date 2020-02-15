using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Shop : IShop
    {
        private int _upgradeLevel, _incomePerMinute, _costToUpgrade, _costToRenovate, _millisecondsUntilReady, _id, _gameId;
        private string _name;
        private ShopLevel _baseLevel;
        private bool _beingRenovated;

        public int UpgradeLevel { get => _upgradeLevel; set => _upgradeLevel = value; }
        public int IncomePerMinute { get => _incomePerMinute; set => _incomePerMinute = value; }
        public string Name { get => _name; set => _name = value; }
        public int CostToRenovate { get => _costToRenovate; set => _costToRenovate = value; }
        public int CostToUpgrade { get => _costToUpgrade; set => _costToUpgrade = value; }
        public ShopLevel BaseLevel { get => _baseLevel; set => _baseLevel = value; }
        public bool BeingRenovated { get => _beingRenovated; set => _beingRenovated = value; }
        public int MillisecondsUntilReady { get => _millisecondsUntilReady; set => _millisecondsUntilReady = value; }
        public int Id { get => _id; set => _id = value; }

        public Shop(string name, int id, int gameId)
        {
            _baseLevel = 0;
            _name = name;
            _upgradeLevel = 0;
            _incomePerMinute = 20;
            _costToUpgrade = 100;
            _costToRenovate = 600;
            _beingRenovated = false;
            _id = id;
            _gameId = gameId;
        }

        public Shop(string name, int id, int gameId, int baselvl, int upgradelvl, int income, int costToUpgrade,
            int costToRenovate, int renovated, int milliseconds)
        {
            _name = name;
            _id = id;
            _gameId = gameId;
            _baseLevel = (ShopLevel)baselvl;
            _upgradeLevel = upgradelvl;
            _incomePerMinute = income;
            _costToUpgrade = costToUpgrade;
            _costToRenovate = costToRenovate;
            if (renovated == 1)
                _beingRenovated = true;
            _millisecondsUntilReady = milliseconds;
        }

        public virtual void Renovate()
        {
            if (_baseLevel != ShopLevel.MegaMarket)
            {
                _beingRenovated = true;
                switch(_baseLevel)
                {
                    case ShopLevel.Kiosk: StartUpgrade(120, ShopLevel.Market); break;
                    case ShopLevel.Market: StartUpgrade(360, ShopLevel.SuperMarket); break;
                    case ShopLevel.SuperMarket: StartUpgrade(1080, ShopLevel.MegaMarket); break;
                    default: throw new Exception("This really should not be happening.");
                }
            }
            else throw new Exception("This should not be possible anymore.");
        }

        public virtual void Enhance()
        {
            if (_upgradeLevel != 5)
            {
                switch(_baseLevel)
                {
                    case ShopLevel.Kiosk: _incomePerMinute += 4; _upgradeLevel++; break;
                    case ShopLevel.Market: _incomePerMinute += 10; _upgradeLevel++; break;
                    case ShopLevel.SuperMarket: _incomePerMinute += 22; _upgradeLevel++; break;
                    case ShopLevel.MegaMarket: _incomePerMinute += 45; _upgradeLevel++; break;
                    default: throw new Exception("This really should not be happening.");
                }
            }
            else throw new Exception("This should not be possible anymore.");
        }

        public override string ToString()
        {
            return String.Format("{0}\nLevel {1}\nIncome: {2} per minute.",
                _baseLevel.ToString(), _upgradeLevel, _incomePerMinute);
        }

        private void StartUpgrade(int minutes, ShopLevel goal)
        {
            _millisecondsUntilReady = minutes * 60000;
            _baseLevel = goal;
            _upgradeLevel = 0;
            switch(_baseLevel)
            {
                case ShopLevel.Market: _incomePerMinute = 60; _costToUpgrade = 500; _costToRenovate = 5000; break;
                case ShopLevel.SuperMarket: _incomePerMinute = 200; _costToUpgrade = 2000; _costToRenovate = 25000; break;
                case ShopLevel.MegaMarket: _incomePerMinute = 500; _costToUpgrade = 8000; _costToRenovate = int.MaxValue; break;
                default: throw new Exception("This really should not be happening.");
            }
        }
    }
}
