namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetoEntidade")]
    public partial class projetoEntidade
    {
        [Key]
        [Column("projetoEntidade")]
        public int projetoEntidade1 { get; set; }

        public int projetoEntidade_projetoId { get; set; }

        public int projetoEntidade_entidadeId { get; set; }

        [Required]
        [StringLength(50)]
        public string projetoEntidadePapel { get; set; }

        [StringLength(250)]
        public string projetoEntidadeEspecifcacao { get; set; }

        public virtual entidade entidade { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
