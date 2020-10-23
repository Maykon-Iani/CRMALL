using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMALL.Domain.Entities
{
    [Table("cliente")]
    public class Cliente : Pessoa
    {
        [Key]
        [Column(name: "id")]
        public long Id { get; set; }
        
    }
}
