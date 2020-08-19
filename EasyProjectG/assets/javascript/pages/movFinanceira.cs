namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movFinanceira")]
    public partial class movFinanceira
    {
        public int movFinanceiraId { get; set; }

        [Column(TypeName = "date")]
        public DateTime movFinanceiraData { get; set; }

        public int movFinaceira_projetoId { get; set; }

        [StringLength(50)]
        public string movFinanceiraConta { get; set; }

        [StringLength(1)]
        public string movFinanceiraReceita { get; set; }

        public float movFinanceiraValor { get; set; }

        [StringLength(50)]
        public string movFinanceiraHistorico { get; set; }

        [StringLength(50)]
        public string movFinanceiraRubrica { get; set; }

        public int movFinanceira_nucleoId { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
