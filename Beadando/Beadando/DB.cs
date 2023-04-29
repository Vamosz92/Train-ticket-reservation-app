using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Beadando
{
    class DB
    {
        private SQLiteConnection connection = new SQLiteConnection("data source=C:\\Users\\temes\\source\\repos\\Beadando\\Beadando\\bin\\felhasznalok.db");
    
        //getter
        public SQLiteConnection GetConnection() { return connection; }

        //adatbázis megnyitása
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //adatbázis lezárása
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
