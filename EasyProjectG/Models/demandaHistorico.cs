namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("demandaHistorico")]
    public partial class demandaHistorico
    {
        public int demandaHistoricoId { get; set; }

        public int demandaHistorico_demandaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime demandaHistoricoData { get; set; }

        [Required]
        [StringLength(250)]
        public string demandaHistoricoDescricao { get; set; }

        public virtual demanda demanda { get; set; }
    }
}
