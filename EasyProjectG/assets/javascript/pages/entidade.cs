namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("entidade")]
    public partial class entidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public entidade()
        {
            demanda = new HashSet<demanda>();
            pessoa = new HashSet<pessoa>();
            projeto = new HashSet<projeto>();
            projetoEntidade = new HashSet<projetoEntidade>();
            recurso = new HashSet<recurso>();
            setor = new HashSet<setor>();
            tag = new HashSet<tag>();
        }

        public int entidadeId { get; set; }

        [Required]
        [StringLength(80)]
        public string entidadeRazaoSocial { get; set; }

        [StringLength(10)]
        public string entidadeSigla { get; set; }

        [StringLength(20)]
        public string entidadeFone { get; set; }

        [StringLength(50)]
        public string entidadeSite { get; set; }

        [StringLength(50)]
        public string entidadeFacebook { get; set; }

        [StringLength(50)]
        public string entidadeWhatsapp { get; set; }

        public int entidade_nucleoId { get; set; }

        public int entidade_tipoId { get; set; }

        [StringLength(50)]
        public string entidadeLogradouro { get; set; }

        [StringLength(50)]
        public string entidadeBairro { get; set; }

        [StringLength(10)]
        public string entidadeCEP { get; set; }

        [StringLength(50)]
        public string entidadeCidade { get; set; }

        [StringLength(50)]
        public string entidadePais { get; set; }

        [StringLength(50)]
        public string entidadeEstado { get; set; }

        [StringLength(10)]
        public string entidadeCor { get; set; }

        [StringLength(1)]
        public string entidadeDesativado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? entidadeAtualData { get; set; }

        [StringLength(30)]
        public string entidadeAtualUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<demanda> demanda { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual tipo tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pessoa> pessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projeto> projeto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoEntidade> projetoEntidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recurso> recurso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<setor> setor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tag> tag { get; set; }
    }
}
