namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("funcao")]
    public partial class funcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public funcao()
        {
            projetoPessoa = new HashSet<projetoPessoa>();
        }

        public int funcaoId { get; set; }

        [Required]
        [StringLength(50)]
        public string funcaoDescricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoPessoa> projetoPessoa { get; set; }
    }
}
