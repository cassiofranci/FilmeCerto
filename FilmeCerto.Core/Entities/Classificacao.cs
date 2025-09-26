using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmeCerto.Core.Entities
{
    public class Classificacao
    {       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }

    }
}
