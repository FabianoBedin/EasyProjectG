namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetoMaterial")]
    public partial class projetoMaterial
    {
        public int projetoMaterialId { get; set; }

        public int projetoMaterial_projetoId { get; set; }

        public int projetoMaterial_materialId { get; set; }

        public float projetoMaterialCusto { get; set; }

        public float projetoMaterialQtde { get; set; }

        [StringLength(1)]
        public string projetoMaterialContraPartida { get; set; }

        [StringLength(50)]
        public string projetoMaterialConta { get; set; }

        public int? projetoMaterial_entidadeId { get; set; }

        public virtual material material { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
