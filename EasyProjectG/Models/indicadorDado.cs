namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("indicadorDado")]
    public partial class indicadorDado
    {
        [Key]
        [Column("indicadorDado")]
        public int indicadorDado1 { get; set; }

        public int indicadorDado_indicadorId { get; set; }

        [Column(TypeName = "date")]
        public DateTime indicadorData { get; set; }

        public float? indicadorValor { get; set; }

        [StringLength(10)]
        public string indicadorStatus { get; set; }

        public virtual indicador indicador { get; set; }
    }
}
