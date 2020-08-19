namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("setor")]
    public partial class setor
    {
        public int setorId { get; set; }

        [Required]
        [StringLength(50)]
        public string setorNome { get; set; }

        [StringLength(10)]
        public string setorSigla { get; set; }

        public int setor_entidadeId { get; set; }

        public virtual entidade entidade { get; set; }
    }
}
