using MongoDB.Driver;
using PruebaTecnica.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Persistence.Database
{
    public class MongoDb
    {
        private readonly IMongoDatabase _database;

        public MongoDb(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<ProveedoresCollection> ProveedoresCollection
        {
            get
            {
                return _database.GetCollection<ProveedoresCollection>("ProveedoresCollection");
            }
        }
    }
}
