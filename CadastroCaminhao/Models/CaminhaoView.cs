using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCaminhao.Models
{
    public class CaminhaoView
    {
        public long Id { get; set; }
        public string? Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
