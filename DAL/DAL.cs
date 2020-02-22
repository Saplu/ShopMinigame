using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL
    {
        string _connection;
        SqlConnection _cnn;
        SqlCommand _command;
        SqlDataReader _reader;
        SqlDataAdapter _adapter;
        
        public DAL()
        {
            var cns = new CnnString();
            _connection = cns.cns;
            _cnn = new SqlConnection(_connection);
            _command = new SqlCommand("", _cnn);
            _adapter = new SqlDataAdapter();
        }

        public void Save(DTL.DTLGame game)
        {
            _cnn.Open();
            _command.Parameters.Add("@ID", SqlDbType.Int);
            _command.Parameters["@ID"].Value = game.Id;
            _command.Parameters.Add("@MONEY", SqlDbType.Int);
            _command.Parameters["@MONEY"].Value = game.Money;
            _command.CommandText = "IF EXISTS (SELECT * FROM Games WHERE Id = @ID)" + 
                                   "UPDATE Games SET Timesaved = (SELECT GETDATE())" +
                                   ", Money = @MONEY WHERE Id = @ID " +
                                   "ELSE INSERT INTO Games (Id, Timesaved, Money) " +
                                   "VALUES (@ID,(SELECT GETDATE()),@MONEY);";
            _adapter.UpdateCommand = _command;
            int success = _adapter.UpdateCommand.ExecuteNonQuery();
            //_command.Parameters.Add("@NAME", SqlDbType.Text);
            //foreach(var shop in game.DTLShops)
            //{
            //    _command.CommandText = AddShopToSQLCommand(shop);
            //    success = _adapter.UpdateCommand.ExecuteNonQuery();
            //}
            _command.CommandText = AddShopsToSQLCommand(game.DTLShops);
            success = _adapter.UpdateCommand.ExecuteNonQuery();
            _command.Dispose();
            _cnn.Close();
        }

        public DTL.DTLGame Read(int gameid)
        {
            _cnn.Open();
            var list = new List<DTL.DTLShop>();
            var game = new DTL.DTLGame();
            _command.Parameters.Add("@ID", SqlDbType.Int);
            _command.Parameters["@ID"].Value = gameid;
            _command.CommandText = "SELECT g.Id, g.Timesaved, g.Money, s.id, s.Upgradelvl, s.Income, s.Upgradecost," +
                       "s.Renovatecost, s.Millisecondsuntilready, s.Name, s.Baselvl, s.Beingrenovated" +
                       " FROM Games g, Shops s " +
                       "WHERE s.Gameid = @ID" +
                       " AND g.Id = @ID";
            _reader = _command.ExecuteReader();

            while(_reader.Read())
            {
                game.Id = _reader.GetInt32(0);
                game.LastUpdated = _reader.GetDateTime(1);
                game.Money = _reader.GetInt32(2);
                var shopid = _reader.GetInt32(3);
                var upgradelvl = _reader.GetInt32(4);
                var income = _reader.GetInt32(5);
                var upgradecost = _reader.GetInt32(6);
                var renovatecost = _reader.GetInt32(7);
                var msuntilready = _reader.GetInt32(8);
                var name = _reader.GetString(9);
                var baselvl = _reader.GetInt32(10);
                var renovated = false;
                if (_reader.GetInt32(11) == 1)
                    renovated = true;
                var shop = new DTL.DTLShop(shopid, gameid, upgradelvl, baselvl, income, upgradecost,
                    renovatecost, msuntilready, name, renovated);
                list.Add(shop);
            }
            _command.Dispose();
            _cnn.Close();

            game.DTLShops = list;
            return game;
        }

        public int GetLastShopId(bool shop)
        {
            var value = 1;
            _cnn.Open();
            if (shop == true)
                _command.CommandText = "SELECT Id FROM shops";
            else _command.CommandText = "SELECT Id FROM Games";
            try
            {
                _reader = _command.ExecuteReader();
                while (_reader.Read())
                {
                    value = _reader.GetInt32(0);
                }
            }
            catch (Exception) { }
            _command.Dispose();
            _cnn.Close();
            return value;
        }

        private string AddShopsToSQLCommand(List<DTL.DTLShop> shops)
        {
            var sb = new StringBuilder();
            _command.Parameters.Add("@NAME", SqlDbType.Text);
            foreach (var shop in shops)
            {
                _command.Parameters["@NAME"].Value = shop.Name;
                sb.Append(String.Format("IF EXISTS (SELECT * FROM shops WHERE Id ={0})" +
                    "UPDATE shops SET Upgradelvl ={1}, Income = {2}, Upgradecost = {3}, " +
                    "Renovatecost = {4}, Millisecondsuntilready = {5}, Baselvl = {6}, Beingrenovated = {7} " +
                    "WHERE Id ={0} " +
                    "ELSE INSERT INTO shops (Id, Gameid, Upgradelvl, Income, Upgradecost, Renovatecost, " +
                    "Millisecondsuntilready, Name, Baselvl, Beingrenovated) " +
                    "VALUES ({0}, {8}, {1}, {2}, {3}, {4}, {5}, @NAME, {6}, {7});",
                    shop.Id, shop.UpgradeLevel, shop.IncomePerMinute, shop.CostToUpgrade, shop.CostToRenovate,
                    shop.MillisecondsUntilReady, shop.BaseLevel, shop.BeingRenovated, shop.GameId));
            }

            return sb.ToString();
        }

        private string AddShopToSQLCommand(DTL.DTLShop shop)
        {
            _command.Parameters["@NAME"].Value = shop.Name;
            return String.Format("IF EXISTS (SELECT * FROM shops WHERE Id ={0})" +
                    "UPDATE shops SET Upgradelvl ={1}, Income = {2}, Upgradecost = {3}, " +
                    "Renovatecost = {4}, Millisecondsuntilready = {5}, Baselvl = {6}, Beingrenovated = {7} " +
                    "WHERE Id ={0} " +
                    "ELSE INSERT INTO shops (Id, Gameid, Upgradelvl, Income, Upgradecost, Renovatecost, " +
                    "Millisecondsuntilready, Name, Baselvl, Beingrenovated) " +
                    "VALUES ({0}, {8}, {1}, {2}, {3}, {4}, {5}, @NAME, {6}, {7});",
                    shop.Id, shop.UpgradeLevel, shop.IncomePerMinute, shop.CostToUpgrade, shop.CostToRenovate,
                    shop.MillisecondsUntilReady, shop.BaseLevel, shop.BeingRenovated, shop.GameId);
        }
    }
}
