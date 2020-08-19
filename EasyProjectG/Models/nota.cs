namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nota")]
    public partial class nota
    {
        public int notaId { get; set; }

        public int? nota_projetoEquId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? notaData { get; set; }

        [StringLength(255)]
        public string notaDesc { get; set; }

        [StringLength(80)]
        public string notaTitulo { get; set; }

        public float? notaValor { get; set; }

        [StringLength(20)]
        public string notaCorFundo { get; set; }

        [StringLength(1)]
        public string notaAgenda { get; set; }

        [StringLength(1)]
        public string notastatus { get; set; }

        public int? nota_atividadeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? notaDataEntrega { get; set; }

        [StringLength(2000)]
        public string notaLabels { get; set; }

        [StringLength(2000)]
        public string notaChecklist { get; set; }

        public int? nota_usuarioId { get; set; }

        [StringLength(20)]
        public string notaId2 { get; set; }

        public int? nota_projetoId { get; set; }

        public virtual atividade atividade { get; set; }

        public virtual projeto projeto { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
