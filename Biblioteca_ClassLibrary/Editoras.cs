using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Models
{
    public class Editoras
    {
        public int? IdEditoras { get; set; }
        public string? NameEditoras { get; set; }
        public DateTime? DatePublic { get; set; }
        public List<Livros>? livros { get; set; }
    }
}
