using System.Collections.Generic;
using ApiTweetsReader.Models;
using ApiTweetsReader2.Controllers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiTweetsReader.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class TweetsController : Controller
    { 
        private TweetsDbContext contexto;
        public TweetsController()
        {
            contexto = new TweetsDbContext();
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public IEnumerable<Tweet> Get()
        {
           var tweets = contexto.Tweets.Find(_ => true).ToList();
           return tweets;
        }
    }
}