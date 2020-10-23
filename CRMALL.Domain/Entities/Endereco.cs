using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMALL.Domain.Entities
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [Column(name: "id")]
        public long Id { get; set; }

        [Column(name: "tipo_endereco")]
        public int? TipoEndereco { get; set; }

        [Column(name: "logradouro", TypeName = "varchar(100)")]
        public string Logradouro { get; set; }

        [Column(name: "numero")]
        public int? Numero { get; set; }

        [Column(name: "complemento", TypeName = "varchar(100)")]
        public string Complemento { get; set; }

        [Column(name: "bairro", TypeName = "varchar(100)")]
        public string Bairro { get; set; }

        [Column(name: "cep", TypeName = "varchar(10)")]
        public string Cep { get; set; }

        [Column(name: "cidade", TypeName = "varchar(45)")]
        public string Cidade { get; set; }

        [Column(name: "estado", TypeName = "varchar(20)")]
        public string Estado { get; set; }
    }
}
