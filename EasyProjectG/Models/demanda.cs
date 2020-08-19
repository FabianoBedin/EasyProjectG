namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("demanda")]
    public partial class demanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public demanda()
        {
            demandaHistorico1 = new HashSet<demandaHistorico>();
        }

        public int demandaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime demandaData { get; set; }

        public int demandaStatus { get; set; }

        public int demandaTipoProjeto { get; set; }

        [Required]
        [StringLength(200)]
        public string demandaLabels { get; set; }

        [StringLength(200)]
        public string demandaEscopo { get; set; }

        public int demanda_entidadeId { get; set; }

        public int demanda_pessoaId { get; set; }

        [StringLength(1)]
        public string demandaManterAtivo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? demandaReagendado { get; set; }

        [StringLength(2000)]
        public string demandaHistorico { get; set; }

        public virtual entidade entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<demandaHistorico> demandaHistorico1 { get; set; }
    }
}
