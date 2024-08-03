using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Models
{
   public class Autores
    {
        public int? IdAutores { get; set; }
        public string? NameAutores { get; set; }

        public List<Livros> livros { get; set; }
    }
}
