#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCaminhao.Models;

namespace CadastroCaminhao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosCaminhaoController : ControllerBase
    {
        private readonly CaminhaoContext _context;

        public ModelosCaminhaoController(CaminhaoContext context)
        {
            _context = context;
        }

        // GET: api/ModelosCaminhao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloCaminhao>>> GetModelosCaminhao()
        {
            return await _context.ModelosCaminhao.ToListAsync();
        }

        // GET: api/ModelosCaminhao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloCaminhao>> GetModeloCaminhao(long id)
        {
            var modeloCaminhao = await _context.ModelosCaminhao.FindAsync(id);

            if (modeloCaminhao == null)
            {
                return NotFound();
            }

            return modeloCaminhao;
        }

        // POST: api/ModelosCaminhao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModeloCaminhao>> PostModeloCaminhao(ModeloCaminhao modeloCaminhao)
        {
            _context.ModelosCaminhao.Add(modeloCaminhao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModeloCaminhao", new { id = modeloCaminhao.Id }, modeloCaminhao);
        }

    }
}
