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
    public class CategoriasLiterariasController : ControllerBase
    {
        private readonly IRepository<CategoriasLiterarias> _categoriasLiterariasRepository;

        public CategoriasLiterariasController(IRepository<CategoriasLiterarias> categoriasLiterariasRespository)
        {
            _categoriasLiterariasRepository = categoriasLiterariasRespository;
        }

        // GET: api/CategoriasLiterarias
        [HttpGet]
        public IEnumerable<CategoriasLiterarias> GetCategoriasLiterarias()
        {
            return _categoriasLiterariasRepository.All();
        }

        // GET: api/CategoriasLiterarias/5
        [HttpGet("{id}")]
        public CategoriasLiterarias GetCategoriasLiterarias(int id)
        {
            var categoriasLiterarias = _categoriasLiterariasRepository.Get(id);

            return categoriasLiterarias;
        }

        // PUT: api/CategoriasLiterarias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutCategoriasLiterarias(int? id, CategoriasLiterarias categoriasLiterarias)
        {
            if (id != categoriasLiterarias.CategoriasLiterariasId)
            {
                return;
            }

           

            try
            {
                _categoriasLiterariasRepository.Update(categoriasLiterarias);
            }
            catch (DbUpdateConcurrencyException)
            {
                 throw;
           
            }

            return;
        }

        // POST: api/CategoriasLiterarias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriasLiterarias>> PostCategoriasLiterarias(CategoriasLiterarias categoriasLiterarias)
        {
            _categoriasLiterariasRepository.Add(categoriasLiterarias);
            

            return CreatedAtAction("GetCategoriasLiterarias", new { id = categoriasLiterarias.CategoriasLiterariasId }, categoriasLiterarias);
        }

        // DELETE: api/CategoriasLiterarias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriasLiterarias(int id)
        {
            _categoriasLiterariasRepository.Delete(id);
            return NoContent();
        }

        private bool CategoriasLiterariasExists(int? id)
        {
            return _categoriasLiterariasRepository.All().Any(e => e.CategoriasLiterariasId == id);
        }
    }
}
