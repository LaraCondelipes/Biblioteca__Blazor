using Biblioteca_API.Data;
using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca_API.Repository
{
    public class LivrosRepository : IRepository<Livros>
    {
        public readonly BibliotecaDbContext context;

        public LivrosRepository(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public Livros Add(Livros entity)
        {
            context.Livros.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public IEnumerable<Livros> All()
        {
            return context
                .Livros
                .Include(c => c.autores)
                .Include(c => c.editoras)
                .ToList();


        }

        public Livros? Get(int id)
        {
            return context
                .Livros
                .Include(c => c.editoras)
                .Include(c => c.autores)
                .FirstOrDefault(b => b.LivroId == id);
        }

        public Livros Update(Livros entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public Livros Delete(int id)
        {
            var entity = Get(id);

            if (entity != null)
            {
                context.Livros.Remove(entity);
                context.SaveChanges();
            }
            return entity;

        }
    }
}
