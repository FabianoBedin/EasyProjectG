namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projeto")]
    public partial class projeto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projeto()
        {
            agenda = new HashSet<agenda>();
            atividade = new HashSet<atividade>();
            etapa = new HashSet<etapa>();
            indicador = new HashSet<indicador>();
            meta = new HashSet<meta>();
            movFinanceira = new HashSet<movFinanceira>();
            nota = new HashSet<nota>();
            projetoAquisicao = new HashSet<projetoAquisicao>();
            projetoEntidade = new HashSet<projetoEntidade>();
            projetoMaterial = new HashSet<projetoMaterial>();
            projetoPessoa = new HashSet<projetoPessoa>();
            projetoRecurso = new HashSet<projetoRecurso>();
            tarefa = new HashSet<tarefa>();
            tag = new HashSet<tag>();
        }

        public int projetoId { get; set; }

        public int projeto_tipoId { get; set; }

        [Required]
        [StringLength(80)]
        public string projetoNome { get; set; }

        [Required]
        [StringLength(600)]
        public string projetoObjetivo { get; set; }

        [Column(TypeName = "date")]
        public DateTime projetoData { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetoDataIni { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetoDataFim { get; set; }

        [StringLength(7)]
        public string projetoSemestre { get; set; }

        public int projetoResp_pessoaId { get; set; }

        [StringLength(20)]
        public string projetoContaCusto { get; set; }

        [StringLength(20)]
        public string projetoContaIntegracao { get; set; }

        [StringLength(1)]
        public string projetoCompartilhado { get; set; }

        public int projeto_usuarioId { get; set; }

        [Column(TypeName = "date")]
        public DateTime projetoDataAtualizado { get; set; }

        [StringLength(50)]
        public string projetoPasta { get; set; }

        public int? projetoVinculo_projetoId { get; set; }

        public int? projetoMonitoramento { get; set; }

        public float? projetoResultadoPrevisto { get; set; }

        public float? projetoTaxas { get; set; }

        public int? projeto_setorId { get; set; }

        public int? projetoGestora_entidadeId { get; set; }

        [StringLength(10)]
        public string projetoCor { get; set; }

        public int? projeto_statusTipoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agenda> agenda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<atividade> atividade { get; set; }

        public virtual entidade entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<etapa> etapa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<indicador> indicador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meta> meta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movFinanceira> movFinanceira { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nota> nota { get; set; }

        public virtual pessoa pessoa { get; set; }

        public virtual tipo tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoAquisicao> projetoAquisicao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoEntidade> projetoEntidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoMaterial> projetoMaterial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoPessoa> projetoPessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoRecurso> projetoRecurso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarefa> tarefa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tag> tag { get; set; }
    }
}
