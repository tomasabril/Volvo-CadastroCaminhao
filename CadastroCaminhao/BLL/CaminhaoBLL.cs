using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCaminhao.Models;

// Class to hold Business logic
namespace CadastroCaminhao.Business
{
    public class CaminhaoBLL
    {
        private readonly CaminhaoContext _context;
        public CaminhaoBLL(CaminhaoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CaminhaoView>> GetCaminhoes()
        {
            var caminhoes = await _context.Caminhoes.ToListAsync();
            var caminhoesView = new List<CaminhaoView> { };
            foreach (var c in caminhoes)
            {
                caminhoesView.Add(CaminhaoToCaminhaoView(c));
            }
            return caminhoesView;
        }
        public async Task<CaminhaoView> GetCaminhao(long id)
        {
            var caminhao = await _context.Caminhoes.FindAsync(id);

            if (caminhao == null)
            {
                return null;
            }

            return CaminhaoToCaminhaoView(caminhao);
        }
        public async Task<int> UpdateCaminhao(long id, Caminhao caminhao)
        {
            if (!ValidateCaminhao(caminhao))
            {
                return 400;
            }
            if (!CaminhaoExists(id))
            {
                return 404;
            }

            _context.Entry(caminhao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return 204;
        }
        public async Task<Caminhao> CreateCaminhao(Caminhao caminhao)
        {
            if (ValidateCaminhao(caminhao))
            {
                _context.Caminhoes.Add(caminhao);
                await _context.SaveChangesAsync();
                return caminhao;
            }
            return null;
        }
        public async Task<int> DeleteCaminhao(long id)
        {
            var caminhao = await _context.Caminhoes.FindAsync(id);
            if (caminhao == null)
            {
                return 404;
            }

            _context.Caminhoes.Remove(caminhao);
            await _context.SaveChangesAsync();

            return 204;
        }

        private bool CaminhaoExists(long id)
        {
            return _context.Caminhoes.Any(e => e.Id == id);
        }

        private CaminhaoView CaminhaoToCaminhaoView(Caminhao caminhao)
        {
            var modeloCaminhao = _context.ModelosCaminhao.Find(caminhao.ModeloCaminhaoId);

            return new CaminhaoView
            {
                Id = caminhao.Id,
                Modelo = modeloCaminhao?.Name,
                AnoFabricacao = caminhao.AnoFabricacao,
                AnoModelo = caminhao.AnoModelo
            };
        }

        private bool ValidateCaminhao(Caminhao caminhao)
        {
            if (caminhao.AnoFabricacao == DateTime.Now.Year
                && caminhao.AnoModelo >= DateTime.Now.Year
                && _context.ModelosCaminhao.Find(caminhao.ModeloCaminhaoId) != null)
            {
                return true;
            }
            return false;
        }

    }
}