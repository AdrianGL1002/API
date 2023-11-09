using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiPostgreSQL.Data
{
    public class PostgresSQLConfiguraction
    {
        
        public PostgresSQLConfiguraction(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }
    }
}
