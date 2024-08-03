namespace Biblioteca_Models
{
    public class Livros
    {
        public int? IdLivro { get; set; }
        public string? Titulo { get; set; }
        public virtual Autores? autores { get; set; }
        public virtual Editoras? editoras { get; set; }

    }
}
