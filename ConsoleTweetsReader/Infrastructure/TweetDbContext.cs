using ConsoleTweetsReader.Models;
using MongoDB.Driver;

namespace ConsoleTweetsReader.Infrastructure
{
    public class TweetDbContext
    {
        private readonly IMongoDatabase database;

        public TweetDbContext()
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