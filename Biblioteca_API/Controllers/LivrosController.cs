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
    public class LivrosController : ControllerBase
    {
        private readonly IRepository<Livros> _livrosRepository;

        public LivrosController(IRepository<Livros> livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        // GET: api/Livros
        [HttpGet]
        public IEnumerable<Livros> GetLivros()
        {
            return _livrosRepository.All();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public Livros GetLivros(int id)
        {
            var livros = _livrosRepository.Get(id);
                     
            return livros;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutLivros(int? id, Livros livros)
        {
            if (id != livros.EditorasId)
            {
                return;
            }

            try
            {
                _livrosRepository.Update(livros);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

            return;
        }

        // POST: api/Livros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivros(Livros livros)
        {
            _livrosRepository.Add(livros);
           

            return CreatedAtAction("GetLivros", new { id = livros.EditorasId }, livros);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivros(int id)
        {
           

            _livrosRepository.Delete(id);
            

            return NoContent();
        }

        private bool LivrosExists(int? id)
        {
            return _livrosRepository.All().Any(e => e.EditorasId == id);
        }
    }
}
