using Biblioteca_API.Data;
using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Repository
{
    
    
        public class AvaliacaoRepository : IRepository<Avaliacao>
        {

            private readonly BibliotecaDbContext context;

            public AvaliacaoRepository(BibliotecaDbContext context)
            {
                this.context = context;
            }


            public IEnumerable<Avaliacao> All()
            {
                return context
                      .Avaliacao
                      .Include(c => c.livros)
                      .ToList();
            }

            public Avaliacao? Get(int id)
            {
                return context
               .Avaliacao
               .Include(c => c.livros)
               .FirstOrDefault(c => c.AvaliacaoId == id);
            }

            public Avaliacao Add(Avaliacao entity)
            {
                context.Avaliacao.Add(entity);
                context.SaveChanges();

                return entity;
            }

            public Avaliacao Update(Avaliacao entity)
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
            public Avaliacao Delete(int id)
            {
                var entity = Get(id);
                if (entity != null)
                {
                    context.Avaliacao.Remove(entity);
                    context.SaveChanges();
                }

                return entity;
            }


        }
    }

