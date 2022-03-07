#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCaminhao.Models;
using CadastroCaminhao.Business;

namespace CadastroCaminhao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhoesController : ControllerBase
    {
        //private readonly CaminhaoContext _context;
        private CaminhaoBLL _CaminhaoBLL;

        public CaminhoesController(CaminhaoContext context)
        {
            //_context = context;
            _CaminhaoBLL = new CaminhaoBLL(context);
        }

        // GET: api/Caminhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaminhaoView>>> GetCaminhoes()
        {
            var caminhoes = await _CaminhaoBLL.GetCaminhoes();
            return caminhoes.ToList();
        }

        // GET: api/Caminhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaminhaoView>> GetCaminhao(long id)
        {
            var caminhao = await _CaminhaoBLL.GetCaminhao(id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return caminhao;
        }

        // PUT: api/Caminhoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaminhao(long id, Caminhao caminhao)
        {
            if (id != caminhao.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _CaminhaoBLL.UpdateCaminhao(id, caminhao);
                switch (result)
                {
                    case 400:
                        return BadRequest("Invalid Caminhao.");
                    case 404:
                        return NotFound();
                    default:
                        return NoContent();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // POST: api/Caminhoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caminhao>> PostCaminhao(Caminhao caminhao)
        {
            var createdCaminhao = await _CaminhaoBLL.CreateCaminhao(caminhao);
            if (createdCaminhao == null)
            {
                return BadRequest("Invalid Caminhao.");
            }

            return CreatedAtAction(nameof(GetCaminhao), new { id = createdCaminhao.Id }, createdCaminhao);
        }

        // DELETE: api/Caminhoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaminhao(long id)
        {
            var status = await _CaminhaoBLL.DeleteCaminhao(id);
            if (status == 404)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
