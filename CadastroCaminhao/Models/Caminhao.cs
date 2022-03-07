using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCaminhao.Models
{
    public class Caminhao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("ModeloCaminhaoId")]
        public long ModeloCaminhaoId { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }
}
