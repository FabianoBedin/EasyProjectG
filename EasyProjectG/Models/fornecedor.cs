namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fornecedor")]
    public partial class fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fornecedor()
        {
            projetoAquisicao = new HashSet<projetoAquisicao>();
        }

        public int fornecedorId { get; set; }

        [Required]
        [StringLength(50)]
        public string fornecedorNome { get; set; }

        [StringLength(50)]
        public string fornecedorSite { get; set; }

        [Required]
        [StringLength(50)]
        public string fornecedorFone { get; set; }

        [StringLength(20)]
        public string fornecedorWhatts { get; set; }

        [StringLength(50)]
        public string fornecedorEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoAquisicao> projetoAquisicao { get; set; }
    }
}
