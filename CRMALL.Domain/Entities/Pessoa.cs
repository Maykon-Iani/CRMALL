using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRMALL.Domain.Entities
{
    public abstract class Pessoa
    {
        [Column(name: "nome", TypeName = "varchar(100)")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [JsonIgnore]
        [Column(name: "sexo")]
        [DisplayName("Sexo")]
        public int? Sexo { get; set; }

        [JsonIgnore]
        [Column(name: "data_nascimento")]
        [DisplayName("Nascimento")]
        public DateTime? DataNascimento { get; set; }


        #region Relationships

        [JsonIgnore]
        [ForeignKey("endereco_id")]
        public Endereco Endereco { get; set; }

        #endregion
    }
}
