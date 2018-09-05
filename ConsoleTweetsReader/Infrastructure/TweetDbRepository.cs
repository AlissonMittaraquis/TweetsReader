using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleTweetsReader.Models;

namespace ConsoleTweetsReader.Infrastructure
{
    public class TweetDbRepository
    {
        public async void SalvarTweetAsync(Tweet tweet)
        {
            //Inicializando o contexto e conectando na base mongo
            var contexto = new TweetDbContext();

            //Persistindo o Bson do tweet na collection Tweets
            await contexto.Tweets.InsertOneAsync(tweet);

        }

        public void ZerarBaseTweets()
        {
            //Inicializando o contexto e conectando na base mongo
            var contexto = new TweetDbContext();

            contexto.Tweets.DeleteMany("{ }");

        }
    }
}