using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_API.Data;
using Biblioteca_Models;
using Biblioteca_API.Repository;

namespace Biblioteca_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IRepository<Autores> _autoresRepository;


        public AutoresController(IRepository<Autores> autoresRepository)
                    {
            _autoresRepository = autoresRepository;
        }

        // GET: api/Autores
        [HttpGet]
        public IEnumerable<Autores> GetAutores()
        {
            return  _autoresRepository.All();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public Autores GetAutores(int id)
        {
            var autores = _autoresRepository.Get(id);

            return autores;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutAutores(int id, Autores autores)
        {
            if (id != autores.AutoresId)
            {
                return;
            }
                      
            try
            {
                _autoresRepository.Update(autores); 
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

            return;
        }

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autores>> PostAutores(Autores autores)
        {
            _autoresRepository.Add(autores);
            

            return CreatedAtAction("GetAutores", new { id = autores.AutoresId }, autores);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutores(int id)
        {
            

            _autoresRepository.Delete(id);
            
            return NoContent();
        }

        private bool AutoresExists(int? id)
        {
            return _autoresRepository.All().Any(e => e.AutoresId == id);
        }
    }
}
