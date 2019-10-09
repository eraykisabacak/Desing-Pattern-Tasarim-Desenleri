using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class DataBaseConnection
    {
        private static DataBaseConnection _dataBaseConnection;
        private DataBaseConnection()
        {
            // Constructor
        }

        public static DataBaseConnection CreateConnection()
        {
            if (_dataBaseConnection == null)
            {
                _dataBaseConnection = new DataBaseConnection();
            }
            return _dataBaseConnection;
        }

        public string getData()
        {
            return "Database Connection";
        }
    }
}
