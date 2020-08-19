namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tag")]
    public partial class tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tag()
        {
            entidade = new HashSet<entidade>();
            projeto = new HashSet<projeto>();
        }

        public int tagId { get; set; }

        [Required]
        [StringLength(20)]
        public string tagNome { get; set; }

        public int? tag_tipoId { get; set; }

        [StringLength(10)]
        public string tagCor { get; set; }

        public virtual tipo tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entidade> entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projeto> projeto { get; set; }
    }
}
