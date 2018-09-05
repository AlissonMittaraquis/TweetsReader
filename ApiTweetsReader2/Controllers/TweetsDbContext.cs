using ApiTweetsReader.Models;
using MongoDB.Driver;

namespace ApiTweetsReader2.Controllers
{
    public class TweetsDbContext
    {

        private readonly IMongoDatabase database;

        public TweetsDbContext()
        {
            database = new MongoClient("mongodb+srv://alissonDBA:testeitau.123@cluster0-nqx36.mongodb.net/test?retryWrites=true").GetDatabase("TweetsReader");
        }

        public IMongoCollection<Tweet> Tweets
        {
            get
            {
                return database.GetCollection<Tweet>("Tweets");
            }

        }
    }
}