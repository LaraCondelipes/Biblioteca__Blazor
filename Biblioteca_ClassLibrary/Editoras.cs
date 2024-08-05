using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Models
{
    public class Editoras
    {
        public int? EditorasId { get; set; }
        public string? EditorasName { get; set; }
        public DateTime? DatePublic { get; set; }
        public List<Livros>? livros { get; set; }
    }
}
