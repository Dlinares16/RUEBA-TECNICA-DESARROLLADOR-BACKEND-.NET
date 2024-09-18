using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Core.Domain;
using PruebaTecnica.Core.Service.Contracts;
using PruebaTecnica.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Service.Code.Queries
{
    public class ProveedorQueries : IProveedorQueries
    {
        private readonly MongoDb _MongoDb;
        public ProveedorQueries(MongoDb mongoDb)
        {
            _MongoDb = mongoDb;
        }
        public async Task<ProveedoresCollection> DetalleProveedor(string id)
        {
            try
            {
                return await _MongoDb.ProveedoresCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProveedoresCollection>> ListarProveedor()
        {
            try
            {
                return await _MongoDb.ProveedoresCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
