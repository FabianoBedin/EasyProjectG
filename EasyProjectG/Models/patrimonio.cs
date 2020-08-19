namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("patrimonio")]
    public partial class patrimonio
    {
        public int patrimonioId { get; set; }

        [Required]
        [StringLength(50)]
        public string patrimonioNumero { get; set; }

        [StringLength(50)]
        public string patrimonioFoto { get; set; }

        [StringLength(50)]
        public string patrimonioPasta { get; set; }

        [StringLength(50)]
        public string patrimonioDoc { get; set; }

        [StringLength(50)]
        public string patrimonioNotaFiscal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? patrimonioData { get; set; }

        [StringLength(50)]
        public string patrimonioCheque { get; set; }

        [StringLength(50)]
        public string patrimonioLocalInstalacao { get; set; }

        [StringLength(50)]
        public string patrimonioRubrica { get; set; }

        [StringLength(50)]
        public string patrimonioEmpenho { get; set; }

        public int? patrimonioAno { get; set; }

        [StringLength(250)]
        public string patrimonioEspecificacao { get; set; }

        [StringLength(50)]
        public string patrimonioOrigemRecurso { get; set; }

        public int? parimonio_nucleoId { get; set; }

        public virtual projetoAquisicao projetoAquisicao { get; set; }
    }
}
