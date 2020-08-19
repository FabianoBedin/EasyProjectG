namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class status
    {
        public int statusId { get; set; }

        [Required]
        [StringLength(50)]
        public string statusNome { get; set; }

        public int status_tipoId { get; set; }

        public int? status_nucleoId { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual tipo tipo { get; set; }
    }
}
