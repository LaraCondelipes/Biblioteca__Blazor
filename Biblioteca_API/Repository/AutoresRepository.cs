using Biblioteca_API.Data;
using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca_API.Repository
{
    public class AutoresRepository : IRepository<Autores>
    {

        private readonly BibliotecaDbContext context;

        public AutoresRepository(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Autores> All()
        {
            return context
                .Autores
                .Include(c => c.livros)
                .ToList();
        }
        public Autores? Get(int id)
        {
            return context
                .Autores
                .Include(c => c.livros)
                .FirstOrDefault(c => c.AutoresId == id);
        }
        public Autores Add(Autores entity)
        {
            context.Autores.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public Autores Update(Autores entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }


        public Autores Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                context.Autores.Remove(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}
