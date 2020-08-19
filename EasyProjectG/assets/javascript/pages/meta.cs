namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("meta")]
    public partial class meta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public meta()
        {
            atividade = new HashSet<atividade>();
        }

        public int metaId { get; set; }

        [Required]
        [StringLength(50)]
        public string metaNome { get; set; }

        [StringLength(200)]
        public string metaDefinicao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? metaData { get; set; }

        public float? metaQuantidade { get; set; }

        public float? metaValor { get; set; }

        public int? meta_projetoId { get; set; }

        public int? meta_tipoId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? metaDataLimite { get; set; }

        public int? metaResp_pessoaId { get; set; }

        public int? metaPai_metaId { get; set; }

        public int? meta_indicadorId { get; set; }

        public int? metaStatus_tipoId { get; set; }

        [StringLength(50)]
        public string metaPastaDoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atividade> atividade { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
