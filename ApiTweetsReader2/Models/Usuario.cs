using System;

namespace ApiTweetsReader.Models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public long NumeroSeguidores { get; set; }

        public string Idioma { get; set; }

        public string Localizacao { get; set; }
    }
}