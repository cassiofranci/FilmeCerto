using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmeCerto.Core.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }        
        public int Ano { get; set; }       
        public int DuracaoEmMinutos { get; set; }
        public string Sinopse { get; set; }
        public string Diretor { get; set; }
        public string ElencoPrincipal { get; set; }
        public string UrlPoster { get; set; }   
        public int TipoId { get;  set; }
        public TipoFilme Tipo { get;  set; }
        public int ClassificacaoId { get;  set; }
        public Classificacao Classificacao { get;  set; }
        public List<int> GenerosIds { get; set; }
        public List<FilmeGenero> Generos { get; set; }
    }
}
