using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Models
{
    public class Avaliacao
    {
        public int? AvaliacaoId { get; set; }
        public string? AvaliacaoName { get; set; }
        public List<Livros>? livros { get; set; } 
    }
}
