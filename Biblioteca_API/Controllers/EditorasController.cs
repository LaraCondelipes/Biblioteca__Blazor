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
    public class EditorasController : ControllerBase
    {
        private readonly IRepository<Editoras> _editorasRepository;

        public EditorasController(IRepository<Editoras> editorasRepository)
        {
            _editorasRepository = editorasRepository;
        }

        // GET: api/Editoras
        [HttpGet]
        public IEnumerable<Editoras> GetEditoras()
        {
            return _editorasRepository.All();
        }

        // GET: api/Editoras/5
        [HttpGet("{id}")]
        public Editoras GetEditoras(int id)
        {
            var editoras = _editorasRepository.Get(id);
                       
            return editoras;
        }

        // PUT: api/Editoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void  PutEditoras(int? id, Editoras editoras)
        {
            if (id != editoras.EditorasId)
            {
                return;
            }

            

            try
            {
                _editorasRepository.Update(editoras);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

            return;
        }

        // POST: api/Editoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editoras>> PostEditoras(Editoras editoras)
        {
            _editorasRepository.Add(editoras);
            

            return CreatedAtAction("GetEditoras", new { id = editoras.EditorasId }, editoras);
        }

        // DELETE: api/Editoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditoras(int id)
        {
            _editorasRepository.Delete(id);
                    
            return NoContent();
        }

        private bool EditorasExists(int? id)
        {
            return _editorasRepository.All().Any(e => e.EditorasId == id);
        }
    }
}
