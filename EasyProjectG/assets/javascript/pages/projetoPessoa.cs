namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projetoPessoa")]
    public partial class projetoPessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int projetoPessoaId { get; set; }

        public int projetoPessoa_pessoaId { get; set; }

        public int projetoPessoa_tipoId { get; set; }

        public int? projetoPessoa_funcaoId { get; set; }

        public float? projetoPessoaCustoHora { get; set; }

        public float? projetoPessoaQtdeHoraSemanal { get; set; }

        public float? projetoPessoaQtdeSemana { get; set; }

        [StringLength(1)]
        public string projetoPessoaContrapartida { get; set; }

        [StringLength(50)]
        public string projetoPessoaConta { get; set; }

        public int? projetoPessoaAcesso_tipoId { get; set; }

        public int? projetoPessoa_projetoId { get; set; }

        public int? projetoPessoa_atividadeId { get; set; }

        public virtual funcao funcao { get; set; }

        public virtual pessoa pessoa { get; set; }

        public virtual projeto projeto { get; set; }

        public virtual tipo tipo { get; set; }
    }
}
