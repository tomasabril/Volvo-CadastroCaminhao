using System;
using Xunit;
using CadastroCaminhao.Business;
using CadastroCaminhao.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhao.Test;

public class UnitTest1
{
    private CaminhaoBLL _CaminhaoBLL;
    private CaminhaoContext _context_test;
    public UnitTest1()
    {
        var optionsBuilder = new DbContextOptionsBuilder<CaminhaoContext>();
        optionsBuilder.UseInMemoryDatabase("Caminhoes_Test");
        _context_test = new CaminhaoContext(optionsBuilder.Options);

        _CaminhaoBLL = new CaminhaoBLL(_context_test);
    }

    private void SetupTestDb()
    {
        _context_test.Database.EnsureDeleted();

        var mc1 = new ModeloCaminhao();
        mc1.Name = "FH";
        var mc2 = new ModeloCaminhao();
        mc2.Name = "FM";

        var c1 = new Caminhao();
        c1.ModeloCaminhaoId = 1;
        c1.AnoFabricacao = DateTime.Now.Year;
        c1.AnoModelo = DateTime.Now.Year;
        var c2 = new Caminhao();
        c2.ModeloCaminhaoId = 1;
        c2.AnoFabricacao = DateTime.Now.Year;
        c2.AnoModelo = DateTime.Now.Year + 1;
        var c3 = new Caminhao();
        c3.ModeloCaminhaoId = 2;
        c3.AnoFabricacao = DateTime.Now.Year;
        c3.AnoModelo = DateTime.Now.Year + 2;

        _context_test.Add(mc1);
        _context_test.Add(mc2);
        _context_test.Add(c1);
        _context_test.Add(c2);
        _context_test.Add(c3);

        _context_test.SaveChanges();
        // foreach (var element in _context_test.Caminhoes.ToList())
        // {
        //     Console.Write("id: " + element.Id + " ");
        // }
        // Console.Write("\n ");
    }

    [Fact]
    public void GetCaminhoes_Test()
    {
        SetupTestDb();

        var caminhoes = _CaminhaoBLL.GetCaminhoes().Result.Count();
        Assert.True(
            caminhoes == 3, "Did not return all caminhoes. Returned " + caminhoes
        );
    }

    [Fact]
    public void GetCaminhao_Test()
    {
        SetupTestDb();

        var caminhao = _CaminhaoBLL.GetCaminhao(1).Result;
        Assert.True(caminhao.Id == 1, "Could not get Caminhao by id");
        Assert.True(caminhao.Modelo == "FH", "Could not get Caminhao by id");
        Assert.True(caminhao.AnoFabricacao == DateTime.Now.Year, "Could not get Caminhao by id");
        Assert.True(caminhao.AnoModelo == DateTime.Now.Year, "Could not get Caminhao by id");
    }

    [Fact]
    public void UpdateCaminhao_Test()
    {
        SetupTestDb();

        var c = _context_test.Caminhoes.Find((long)1);

        c.ModeloCaminhaoId = 2;
        var status1 = _CaminhaoBLL.UpdateCaminhao(1, c).Result;
        Assert.True(status1 == 204, "Product not updated. " + status1);

        c.ModeloCaminhaoId = 1;
        c.AnoFabricacao = DateTime.Now.Year - 1;
        var status2 = _CaminhaoBLL.UpdateCaminhao(1, c).Result;
        Assert.True(status2 == 400, "Caminhao not identified as invalid. " + status2);

        c.ModeloCaminhaoId = 1;
        c.AnoFabricacao = DateTime.Now.Year;
        c.AnoModelo = DateTime.Now.Year - 1;
        var status3 = _CaminhaoBLL.UpdateCaminhao(1, c).Result;
        Assert.True(status2 == 400, "Caminhao not identified as invalid. " + status3);

        c.ModeloCaminhaoId = 1;
        c.AnoFabricacao = DateTime.Now.Year;
        c.AnoModelo = DateTime.Now.Year;
        var status4 = _CaminhaoBLL.UpdateCaminhao(99, c).Result;
        Assert.True(status4 == 404, "Product not identified as not existing " + status4);

    }

    [Fact]
    public void CreateCaminhao_Test()
    {
        SetupTestDb();

        var c1 = new Caminhao();
        c1.ModeloCaminhaoId = 1;
        c1.AnoFabricacao = DateTime.Now.Year;
        c1.AnoModelo = DateTime.Now.Year;

        var created = _CaminhaoBLL.CreateCaminhao(c1).Result;
        Assert.True(created != null, "Product not created.");
    }

    [Fact]
    public void DeleteCaminhao_Test()
    {
        SetupTestDb();
    }

    [Fact]
    public void CaminhaoToCaminhaoView_Test()
    {
        SetupTestDb();

        Assert.True(_CaminhaoBLL.DeleteCaminhao(1).Result == 204, "Caminhao not deleted.");
        Assert.True(_CaminhaoBLL.DeleteCaminhao(1).Result == 404, "Nonexistent Caminhao deleted.");
    }

}