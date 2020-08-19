namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agenda
    {
        public int agendaId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime agendaData { get; set; }

        [StringLength(100)]
        public string agendaTitulo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? agendaDataFinal { get; set; }

        [StringLength(50)]
        public string agendaURL { get; set; }

        [StringLength(50)]
        public string agendaOrigem { get; set; }

        [StringLength(5)]
        public string agendaHoraInicio { get; set; }

        [StringLength(5)]
        public string agendaHoraFinal { get; set; }

        [StringLength(12)]
        public string agendaCor { get; set; }

        public int? agenda_nucleoId { get; set; }

        public int? agenda_projetoId { get; set; }

        public int? agenda_usuarioId { get; set; }

        public int? agenda_tarefaId { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual projeto projeto { get; set; }
    }
}
