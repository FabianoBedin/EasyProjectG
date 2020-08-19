namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("etapa")]
    public partial class etapa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public etapa()
        {
            atividade = new HashSet<atividade>();
        }

        public int etapaId { get; set; }

        [Required]
        [StringLength(50)]
        public string etapaNome { get; set; }

        [Required]
        [StringLength(200)]
        public string etapaDescricao { get; set; }

        public int? etapaResp_pessoaId { get; set; }

        public int? etapa_projetoId { get; set; }

        public int? etapaPai_etapaId { get; set; }

        [StringLength(1)]
        public string etapaFlagConcluido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atividade> atividade { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
