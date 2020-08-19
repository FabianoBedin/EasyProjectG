namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("material")]
    public partial class material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public material()
        {
            projetoMaterial = new HashSet<projetoMaterial>();
        }

        public int materialId { get; set; }

        [Required]
        [StringLength(20)]
        public string materialCodigo { get; set; }

        [Required]
        [StringLength(150)]
        public string materialEspecificacao { get; set; }

        public float? materialCusto { get; set; }

        [Required]
        [StringLength(10)]
        public string materialUnidadeMedida { get; set; }

        [StringLength(200)]
        public string materialUso { get; set; }

        [Column(TypeName = "date")]
        public DateTime? materialDataCota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoMaterial> projetoMaterial { get; set; }
    }
}
