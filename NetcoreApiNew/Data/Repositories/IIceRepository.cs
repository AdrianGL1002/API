using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreApiPostgreSQL.Model;

namespace NetCoreApiPostgreSQL.Data.Repositories
{
    public interface IIceRepository
    {
        Task<IEnumerable<IceCream>> GetAllFlavors();
        Task<IceCream> GetFlavor(int id);

        Task<bool> InsertFlavor(IceCream flavors);

        Task<bool> UpdateFlavor(IceCream flavors);

        Task<bool> DeleteFlavor(IceCream flavors);
    }
}
