﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Models
{
    public class CategoriasLiterarias
    {
        public int? CategoriasLiterariasId { get; set; }
        public string? CategoriaLiterariaName { get; set; }
        public List<Livros>? livros { get; set; } 
    }
}
