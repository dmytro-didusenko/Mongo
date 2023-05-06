using Mongo.Models;
using MongoDB.Driver;

namespace Mongo.DataManager
{
    public class MongoDataManager
    {
        private IMongoDatabase _database;

        public MongoDataManager(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var collection = _database.GetCollection<User>("users");
            return await collection.Find("{}").ToListAsync();
        }
    }
}
