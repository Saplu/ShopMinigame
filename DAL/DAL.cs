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

        public void Save(List<DTL.DTLShop> shops, int gameid)
        {

        }

        public List<DTL.DTLShop> Read(int gameid)
        {
            _cnn.Open();
            var list = new List<DTL.DTLShop>();
            _command.CommandText = "SELECT * FROM Shops s WHERE s.Gameid = '" + gameid +"'";
            _reader = _command.ExecuteReader();

            while(_reader.Read())
            {
                var shopid = _reader.GetInt32(0);
                var upgradelvl = _reader.GetInt32(2);
                var income = _reader.GetInt32(3);
                var upgradecost = _reader.GetInt32(4);
                var renovatecost = _reader.GetInt32(5);
                var msuntilready = _reader.GetInt32(6);
                var name = _reader.GetString(7);
                var baselvl = _reader.GetInt32(8);
                var renovated = false;
                if (_reader.GetInt32(9) == 1)
                    renovated = true;
                var shop = new DTL.DTLShop(shopid, gameid, upgradelvl, baselvl, income, upgradecost,
                    renovatecost, msuntilready, name, renovated);
                list.Add(shop);
            }


            return list;
        }
    }
}
