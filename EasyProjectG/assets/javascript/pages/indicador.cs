namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("indicador")]
    public partial class indicador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public indicador()
        {
            indicadorDado = new HashSet<indicadorDado>();
        }

        public int indicadorId { get; set; }

        [Required]
        [StringLength(50)]
        public string indicadorNome { get; set; }

        public int indicador_nucleoId { get; set; }

        [Required]
        [StringLength(250)]
        public string indicadorDefinicao { get; set; }

        [Required]
        [StringLength(20)]
        public string indicadorPeriodiocidade { get; set; }

        [Required]
        [StringLength(8)]
        public string indicadorUM { get; set; }

        public int indicador_tipoId { get; set; }

        [Required]
        [StringLength(50)]
        public string indicadorCaracteristica { get; set; }

        public int? indicador_projetoId { get; set; }

        public int? indicador_metaId { get; set; }

        [StringLength(1)]
        public string indicadorPlanejado { get; set; }

        [StringLength(1)]
        public string indicadorInformado { get; set; }

        [StringLength(10)]
        public string indicadorUnidadeMedida { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual projeto projeto { get; set; }

        public virtual tipo tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<indicadorDado> indicadorDado { get; set; }
    }
}
