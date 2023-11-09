using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiPostgreSQL.Model
{
    public class IceCream
    {
        public int Id { get; set; }
       
        public string? Flavor {  get; set; }

        public int Liters { get; set; }
    }
}
