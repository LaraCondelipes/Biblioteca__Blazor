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
    public class AvaliacaosController : ControllerBase
    {
        private readonly IRepository<Avaliacao> _avaliacaoRepository;

        public AvaliacaosController(IRepository<Avaliacao> avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        // GET: api/Avaliacaos
        [HttpGet]
        public IEnumerable<Avaliacao> GetAvaliacao()
        {
            return _avaliacaoRepository.All();
        }

        // GET: api/Avaliacaos/5
        [HttpGet("{id}")]
        public Avaliacao GetAvaliacao(int id)
        {
            var avaliacao = _avaliacaoRepository.Get(id);

            return avaliacao;
        }

        // PUT: api/Avaliacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.AvaliacaoId)
            {
                return;
            }


            try
            {
                _avaliacaoRepository.Update(avaliacao);
            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
               
            }

            return;
        }

        // POST: api/Avaliacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Add(avaliacao);
           
          return CreatedAtAction("GetAvaliacao", new { id = avaliacao.AvaliacaoId }, avaliacao);
        }

        // DELETE: api/Avaliacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
             _avaliacaoRepository.Delete(id);
            
            return NoContent();
        }

        private bool AvaliacaoExists(int? id)
        {
            return _avaliacaoRepository.All().Any(e => e.AvaliacaoId == id);
        }
    }
}
