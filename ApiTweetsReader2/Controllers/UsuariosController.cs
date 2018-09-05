using System.Collections.Generic;
using System.Linq;
using ApiTweetsReader.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ApiTweetsReader2.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private TweetsDbContext contexto;
        public UsuariosController()
        {
            contexto = new TweetsDbContext();
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public IEnumerable<Usuario> Get()
        {
            return contexto.Tweets.AsQueryable()
                .Select(n => n.Usuario) // Seleciona o documento aninhado
                .Distinct() //Remove duplicados
                .OrderByDescending(x => x.NumeroSeguidores) //Ordena pelos maiores
                .Take(5) //top 5
                .ToList();
        }
    }
}