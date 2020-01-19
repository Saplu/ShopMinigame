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
    }
}
