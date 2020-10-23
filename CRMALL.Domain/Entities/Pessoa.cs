using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMALL.Domain.Entities
{
    public abstract class Pessoa
    {
        [Required]
        [Column(name: "nome", TypeName = "varchar(100)")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column(name: "sexo")]
        [DisplayName("Sexo")]
        public int Sexo { get; set; }

        [Required]
        [Column(name: "data_nascimento")]
        [DisplayName("Nascimento")]
        public DateTime DataNascimento { get; set; }


        #region Relationships

        [JsonIgnore]
        [ForeignKey("endereco_id")]
        public Endereco Endereco { get; set; }

        #endregion
    }
}
