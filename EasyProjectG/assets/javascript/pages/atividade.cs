namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("atividade")]
    public partial class atividade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public atividade()
        {
            nota = new HashSet<nota>();
            tarefa = new HashSet<tarefa>();
        }

        public int atividadeId { get; set; }

        [Required]
        [StringLength(50)]
        public string atividadeNome { get; set; }

        [Required]
        [StringLength(250)]
        public string atividadeDescricao { get; set; }

        public DateTime atividadeDataIni { get; set; }

        public DateTime atividadeDataFim { get; set; }

        public int atividade_etapaId { get; set; }

        public float? atividadeValor { get; set; }

        [StringLength(20)]
        public string atividadeCor { get; set; }

        public float? atividadeQuantidade { get; set; }

        [StringLength(10)]
        public string atividadeUN { get; set; }

        public int? atividade_projetoId { get; set; }

        public int? atividade_metaId { get; set; }

        public virtual etapa etapa { get; set; }

        public virtual meta meta { get; set; }

        public virtual projeto projeto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nota> nota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarefa> tarefa { get; set; }
    }
}
