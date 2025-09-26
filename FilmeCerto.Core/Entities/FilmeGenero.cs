using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmeCerto.Core.Entities
{
    public class FilmeGenero
    {
        public int FilmeId { get; set; }
        [JsonIgnore]
        public Filme Filme { get; set; }

        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
