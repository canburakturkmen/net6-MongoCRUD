using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6_MongoDB
{
    public class MongoDb
    {
        private IMongoDatabase _db;

        public MongoDb(string database)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(database);
        }

        public async Task<T> LoadRecordById<T>(string table, Guid id)
        {
            var collection = _db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", id);

            return await collection.Find(filter).FirstAsync();
        }

        public async Task<List<T>> LoadRecords<T>(string table)
        {
            var collection = _db.GetCollection<T>(table);

            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task InsertRecord<T>(string table, T record)
        {
            var collection = _db.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }

        public async Task UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = _db.GetCollection<T>(table);

            var result = await collection.ReplaceOneAsync(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions
                {
                    IsUpsert = true,
                }
                );
        }

        public async Task DeleteRecord<T>(string table, Guid id)
        {
            var collection = _db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            await collection.DeleteOneAsync(filter);
        }
    }
}
