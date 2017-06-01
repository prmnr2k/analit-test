using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BL.Abstract
{
    public abstract class AbstractDataSource
    {
        private static string connectCfg = "Database=AnalitForm;Data Source=localhost;User Id=root;Password=";

        protected static MySqlConnection _connection = new MySqlConnection(connectCfg);

        
    }
}
