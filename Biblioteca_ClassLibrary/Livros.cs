namespace Biblioteca_Models
{
    public class Livros
    {
        public int LivroId { get; set; }
        public string? Titulo { get; set; }
        public int? AutoresId { get; set; }
        public virtual Autores? autores { get; set; }
        public int? EditorasId { get; set; }
        public virtual Editoras? editoras { get; set; }

    }
}
