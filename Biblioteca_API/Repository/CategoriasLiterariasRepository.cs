using Biblioteca_API.Data;
using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Repository
{
    public class CategoriasLiterariasRepository : IRepository<CategoriasLiterarias>
    {

        private readonly BibliotecaDbContext context;

        public CategoriasLiterarias Add(CategoriasLiterarias entity)
        {
           context.CategoriasLiterarias.Add(entity);
            context.SaveChanges();
        
            return entity;
        }

        public IEnumerable<CategoriasLiterarias> All()
        {
          return context
                .CategoriasLiterarias
                .Include(b => b.livros)
                .ToList();
        }

        public CategoriasLiterarias? Get(int id)
        {
            return context
                .CategoriasLiterarias
                .Include(b => b.livros) 
                .FirstOrDefault();
        }

        public CategoriasLiterarias Update(CategoriasLiterarias entity)
        {
           context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public CategoriasLiterarias Delete(int id)
        {
            var entity = Get(id);

            if (entity != null)
            { 
            context.CategoriasLiterarias .Remove(entity);
                context.SaveChanges();
            }

            return entity;
        }

        
    }
}
