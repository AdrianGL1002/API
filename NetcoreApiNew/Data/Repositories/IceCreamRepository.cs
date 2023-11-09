using Dapper;
using NetCoreApiPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiPostgreSQL.Data.Repositories
{
    public class IceCreamRepository : IIceRepository
    {
        private PostgresSQLConfiguraction _connectionString;

        public IceCreamRepository(PostgresSQLConfiguraction connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection() {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteFlavor(IceCream flavors)
        {
            var db = dbConnection();

            var sql = @" 
                        DELETE
                        FROM public.""icecream"" 
                        WHERE id = @Id 
                       ";
            var result = await db.ExecuteAsync(sql, new { Id = flavors.Id });
            return result > 0;
        }

        public async Task<IEnumerable<IceCream>> GetAllFlavors()
        {
            var db = dbConnection();

            var sql = @" 
                        SELECT id, flavor, liters FROM public.""icecream""
                       ";
            return await db.QueryAsync<IceCream>(sql, new { });
        }

        public async Task<IceCream> GetFlavor(int id)
        {
            var db = dbConnection();

            var sql = @" 
                        SELECT id, flavor, liters FROM public.""icecream""
                        WHERE id = @Id
                        ";
            return await db.QueryFirstOrDefaultAsync<IceCream>(sql, new { Id = id });
        }

        public async Task<bool> InsertFlavor(IceCream flavors)
        {
            var db = dbConnection();

            var sql = @" 
                        INSERT INTO  public.""icecream"" (flavor, liters)
                        VALUES (@Flavor, @Liters)
                       ";
            var result = await db.ExecuteAsync(sql, new { flavors.Flavor, flavors.Liters});
            return result > 0;
        }

        public async Task<bool> UpdateFlavor(IceCream flavors)
        {
            var db = dbConnection();

            var sql = @" 
                        Update  public.""icecream"" 
                        SET flavor = @Flavor,
                            liters = @Liters
                        WHERE id = @Id 
                       ";
            var result = await db.ExecuteAsync(sql, new { flavors.Flavor, flavors.Liters, flavors.Id});
            return result > 0;
        }
    }
}
