using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IShop
    {
        int UpgradeLevel { get; set; }
        ShopLevel BaseLevel { get; set; }
        int IncomePerMinute { get; set; }
        int CostToUpgrade { get; set; }
        int CostToRenovate { get; set; }
        string Name { get; set; }

        void Renovate();
        void Enhance();
    }
}
