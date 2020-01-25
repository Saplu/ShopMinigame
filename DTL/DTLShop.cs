using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL
{
    public class DTLShop
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UpgradeLevel { get; set; }
        public int IncomePerMinute { get; set; }
        public int CostToUpgrade { get; set; }
        public int CostToRenovate { get; set; }
        public int MillisecondsUntilReady { get; set; }
        public string Name { get; set; }
        public int BaseLevel { get; set; }
        public int BeingRenovated { get; set; }

        public DTLShop(int id, int gameId, int upgradelevel, int baselevel, int income, int upgradecost, int renovatecost,
            int milliseconds, string name, bool renovated)
        {
            UpgradeLevel = upgradelevel;
            BaseLevel = baselevel;
            Name = name;
            IncomePerMinute = income;
            CostToUpgrade = upgradecost;
            CostToRenovate = renovatecost;
            MillisecondsUntilReady = milliseconds;
            Id = id;
            GameId = gameId;
            if (renovated)
                BeingRenovated = 1;
            else BeingRenovated = 0;
        }
    }
}
