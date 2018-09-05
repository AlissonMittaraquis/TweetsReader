using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsoleTweetsReader.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace ConsoleTweetsReader.Infrastructure
{
    public class TweetAPIRepository
    {
        HttpClient cliente = new HttpClient();

        public TweetAPIRepository()
        {
            cliente.BaseAddress = new Uri("https://api.twitter.com/1.1/search/tweets.json");

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "AAAAAAAAAAAAAAAAAAAAABF98QAAAAAAJhTo%2BhsjB5q%2Bya9GwNEJ5Ot1DqU%3DJk7m1SR9KjWSXPH8NR3hK79f624MgqwaK1JVNecM8rqs79ytW5");
        }

        public async Task<List<Tweet>> ObterTweetsPorHashtagAsync(string hashtag)
        {
            List<Tweet> listaTweets = new List<Tweet>();

            //Consminto a API do twitter
            HttpResponseMessage resposta = await cliente.GetAsync("?q=%23" + hashtag + "-filter%3Aretweets&count=100");

            if (resposta.IsSuccessStatusCode)
            {
                var dados = await resposta.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(dados);
                IList<JToken> jsonTweets = json["statuses"].Children().ToList();
                foreach (var u in jsonTweets)
                {
                    Tweet tweet = new Tweet();
                    tweet.DataCriacao = (string)u.SelectToken("created_at");
                    tweet.Texto = (string)u.SelectToken("text");
                    foreach (var token in u.SelectTokens("entities.hashtags[*].text"))
                    {
                        tweet.Hashtags.Add(token.ToString());
                    }
                    tweet.Usuario.Idioma = u.SelectToken("user.lang").ToString();
                    tweet.Usuario.Nome = u.SelectToken("user.name").ToString();
                    tweet.Usuario.Localizacao = u.SelectToken("user.location").ToString();
                    tweet.Usuario.NumeroSeguidores = (long)u.SelectToken("user.followers_count");

                    //removendo o lixo do retorno
                    if (tweet.Hashtags.Count != 0)
                    {
                        listaTweets.Add(tweet);
                    }

                }
            }
            return listaTweets;
        }
    }
}