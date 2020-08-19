namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetoAquisicao")]
    public partial class projetoAquisicao
    {
        public int projetoAquisicaoId { get; set; }

        [StringLength(150)]
        public string projetoAquisicaoEspeficicacao { get; set; }

        [StringLength(250)]
        public string projetoAquisicaoJustificativa { get; set; }

        [StringLength(600)]
        public string projetoAquisicaoDetalhamento { get; set; }

        public int projetoAquisicao_projetoId { get; set; }

        [Column(TypeName = "date")]
        public DateTime projetoAquisicaoDataLimite { get; set; }

        [Required]
        [StringLength(50)]
        public string projetoAquisicaoStatus { get; set; }

        public int? projetoAquisicao_pessoaId { get; set; }

        public float projetoAquisicaoValorEstimado { get; set; }

        public float? projetoAquisicaoQtde { get; set; }

        public float? ProjetoAquisicaoValorAquisicao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetoAquisicaoData { get; set; }

        [Column(TypeName = "date")]
        public DateTime? projetoAquisicaoDataStatus { get; set; }

        public int? projetoAquisicao_fornecedorId { get; set; }

        public int? projetoAquisicao_patrimonioId { get; set; }

        public virtual fornecedor fornecedor { get; set; }

        public virtual patrimonio patrimonio { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
