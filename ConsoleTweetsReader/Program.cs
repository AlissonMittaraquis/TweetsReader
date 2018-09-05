using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleTweetsReader.Infrastructure;
using static System.Console;


namespace ConsoleTweetsReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //Iniciando a lista de hashtags
                List<string> hastags = new List<string>();

                hastags.Add("openbanking");
                hastags.Add("apifirst");
                hastags.Add("devops");
                hastags.Add("cloudfirst");
                hastags.Add("microservices");
                hastags.Add("apigateway");
                hastags.Add("oauth");
                hastags.Add("swagger");
                hastags.Add("raml");
                hastags.Add("openapis");

                var repositorioAPI = new TweetAPIRepository();
                var repositorioDB = new TweetDbRepository();

                WriteLine("Limpando Base de dados");
                repositorioDB.ZerarBaseTweets();

                //Iterando na coleção de hashtags para consulta-las e persisti-las
                foreach (string hashtag in hastags)
                {
                    WriteLine("Acessando a API do Twitter filtrando pela hashtag: #" + hashtag);
                    var tweetsTask = repositorioAPI.ObterTweetsPorHashtagAsync(hashtag);

                    tweetsTask.ContinueWith(task =>
                        {
                            var tweets = task.Result;
                            foreach (var tweet in tweets)
                            {
                                WriteLine("Inserindo o tweet coletado na base Mongo para a hashtag: " + hashtag);

                                repositorioDB.SalvarTweetAsync(tweet);
                            }
                        },
                        TaskContinuationOptions.OnlyOnRanToCompletion);
                }

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine(ex.StackTrace);
                throw ex;
            }

            //Impede o encerramento do programa enquanto as tasks assincronas estão executando
            ReadKey();
        }
    }
}
