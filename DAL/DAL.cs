using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _command.CommandText = "IF EXISTS (SELECT * FROM Games WHERE Id = '" + game.Id + "')" + 
                                   "UPDATE Games SET Timesaved = (SELECT GETDATE())" +
                                   ", Money = '" + game.Money + "' WHERE Id = '" + game.Id + "'";
            _adapter.UpdateCommand = _command;
            int success = _adapter.UpdateCommand.ExecuteNonQuery();
            _command.Dispose();
            _cnn.Close();
        }

        public DTL.DTLGame Read(int gameid)
        {
            _cnn.Open();
            var list = new List<DTL.DTLShop>();
            var game = new DTL.DTLGame();
            _command.CommandText = "SELECT g.Id, g.Timesaved, g.Money, s.id, s.Upgradelvl, s.Income, s.Upgradecost," +
                                   "s.Renovatecost, s.Millisecondsuntilready, s.Name, s.Baselvl, s.Beingrenovated" +
                                   " FROM Games g, Shops s " +
                                   "WHERE s.Gameid = '" + gameid +"'" +
                                   " AND g.Id = '" + gameid +"'";
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
    }
}
