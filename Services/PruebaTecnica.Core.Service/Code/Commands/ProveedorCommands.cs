using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Core.Domain;
using PruebaTecnica.Core.Service.Contracts;
using PruebaTecnica.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Service.Code.Commands
{
    public class ProveedorCommands : IProveedorCommands
    {
        private readonly MongoDb _MongoDb;
        public ProveedorCommands(MongoDb mongoDb)
        {
            _MongoDb = mongoDb;
        }

        public async Task ActualizarProveedor(ProveedoresCollection proveedor)
        {
            try
            {
                var filter = Builders<ProveedoresCollection>.Filter.Eq(x => x.Id, proveedor.Id);
                await _MongoDb.ProveedoresCollection.ReplaceOneAsync(filter, proveedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task EliminarProveedor(string id)
        {
            try
            {
                var filter = Builders<ProveedoresCollection>.Filter.Eq(x => x.Id, new ObjectId(id));
                await _MongoDb.ProveedoresCollection.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task InsertarProveedor(ProveedoresCollection proveedor)
        {
            try
            {
                await _MongoDb.ProveedoresCollection.InsertOneAsync(proveedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
