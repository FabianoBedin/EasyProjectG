namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("label")]
    public partial class label
    {
        public int labelId { get; set; }

        public int label_nucleoId { get; set; }

        [Required]
        [StringLength(20)]
        public string labelNome { get; set; }

        [Required]
        [StringLength(20)]
        public string labelSemBrancos { get; set; }

        [Required]
        [StringLength(12)]
        public string labelCor { get; set; }

        [Column(TypeName = "date")]
        public DateTime labelDataDesativado { get; set; }

        public int label_tipoId { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual tipo tipo { get; set; }
    }
}
