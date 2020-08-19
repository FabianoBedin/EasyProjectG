namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetoRecurso")]
    public partial class projetoRecurso
    {
        public int projetoRecursoId { get; set; }

        public int projetoRecurso_projetoId { get; set; }

        public int projetoRecurso_recursoId { get; set; }

        public float? projetoRecursoCustoHora { get; set; }

        public float? projetoRecursoQtdeHora { get; set; }

        [StringLength(1)]
        public string projetoRecursoContrapartida { get; set; }

        [StringLength(50)]
        public string projetoRecursoConta { get; set; }

        public virtual projeto projeto { get; set; }

        public virtual recurso recurso { get; set; }
    }
}
