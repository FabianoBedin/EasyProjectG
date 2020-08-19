namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("recurso")]
    public partial class recurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recurso()
        {
            projetoRecurso = new HashSet<projetoRecurso>();
        }

        public int recursoId { get; set; }

        [Required]
        [StringLength(50)]
        public string recursoNome { get; set; }

        [Required]
        [StringLength(5)]
        public string recursotipo { get; set; }

        public int? recurso_tipoId { get; set; }

        public int? recurso_entidadeId { get; set; }

        public virtual entidade entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoRecurso> projetoRecurso { get; set; }

        public virtual tipo tipo { get; set; }
    }
}
