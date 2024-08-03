using Biblioteca_API.Data;
using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Repository
{
    public class EditorasRepository : IRepository<Editoras>
    {
        private readonly BibliotecaDbContext context;

        public EditorasRepository(BibliotecaDbContext context)
        { 
        this.context = context;
        }

        public Editoras Add(Editoras entity)
        {
           context.Editoras.Add(entity);
            context.SaveChanges();

            return entity;  
        }

        public IEnumerable<Editoras> All()
        {
            return context
                  .Editoras
                  .Include(c => c.livros)
                  .ToList();
        }

        public Editoras? Get(int id)
        {
           return context
                .Editoras
                .Include(c => c.livros)
                .FirstOrDefault();
        }

        public Editoras Update(Editoras entity)
        {
           context.Entry(entity).State = EntityState.Modified;  
            context.SaveChanges();

            return entity;
        }

        public Editoras Delete(int id)
        {
            var entity = Get(id);

            if (entity != null)
            { 
                context.Editoras.Remove(entity);
                context.SaveChanges();  

                
            }
            return entity;
        }

        
    }
}
