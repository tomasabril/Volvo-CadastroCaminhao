using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCaminhao.Models
{
    public class ModeloCaminhao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }
        public string Name { get; set; }
    }
}
