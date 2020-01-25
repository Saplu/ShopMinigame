using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTL
{
    public class DTLGame
    {
        public int Money { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Id { get; set; }
        public List<DTLShop> DTLShops { get; set; }

        public DTLGame(int id, int money, DateTime updated, List<DTLShop> shops)
        {
            Id = id;
            Money = money;
            LastUpdated = updated;
            DTLShops = shops;
        }

        public DTLGame()
        {
            Id = 0;
            Money = 0;
            LastUpdated = DateTime.Now;
            DTLShops = new List<DTLShop>();
        }
    }
}
