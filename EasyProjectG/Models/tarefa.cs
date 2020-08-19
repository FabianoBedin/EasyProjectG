namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tarefa")]
    public partial class tarefa
    {
        public int tarefaId { get; set; }

        [Required]
        [StringLength(60)]
        public string tarefaNome { get; set; }

        public int tarefa_projetoId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tarefaData { get; set; }

        [StringLength(255)]
        public string tarefaDesc { get; set; }

        [StringLength(80)]
        public string tarefaTitulo { get; set; }

        public float? tarefaValor { get; set; }

        [StringLength(20)]
        public string tarefaCorFundo { get; set; }

        [StringLength(1)]
        public string tarefaAgenda { get; set; }

        [StringLength(1)]
        public string tarefastatus { get; set; }

        public int? tarefa_atividadeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tarefaDataEntrega { get; set; }

        [StringLength(2000)]
        public string tarefaLabels { get; set; }

        [StringLength(2000)]
        public string tarefaChecklist { get; set; }

        public int? tarefa_usuarioId { get; set; }

        [StringLength(20)]
        public string tarefaID2 { get; set; }

        [StringLength(12)]
        public string tarefaPrioridade { get; set; }

        public int? tarefa_pessoaId { get; set; }

        public virtual atividade atividade { get; set; }

        public virtual pessoa pessoa { get; set; }

        public virtual projeto projeto { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
