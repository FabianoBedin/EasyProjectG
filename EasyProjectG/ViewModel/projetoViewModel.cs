using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyProjectG.ViewModel
{
    public class projetoViewModel
    {
        
        [DisplayName("Id")]
        public int projetoId { get; set; }

        public int projeto_tipoId { get; set; }

        [Required]
        [StringLength(80)]
        public string projetoNome { get; set; }

        public string projetoResponsavel { get; set; }

        public string projetoGestora { get; set; }

        [StringLength(1)]
        public string projetoLetra{ get; set; }

        [Required]
        [StringLength(600)]
        public string projetoObjetivo { get; set; }

        public string projetoData { get; set; }

        public string projetoDataIni { get; set; }

        public string projetoDataFim { get; set; }

        [StringLength(7)]
        public string projetoSemestre { get; set; }

        public int projetoResp_Id { get; set; }

        [StringLength(20)]
        public string projetoContaCusto { get; set; }

        [StringLength(20)]
        public string projetoContaIntegracao { get; set; }

        [StringLength(1)]
        public string projetoCompartilhado { get; set; }

        public int projeto_usuarioId { get; set; }

        public string projetoDataAtualizado { get; set; }

        [StringLength(50)]
        public string projetoPasta { get; set; }

        public int? projetoVinculo_projetoId { get; set; }

        public int? projetoMonitoramento { get; set; }

        public float? projetoResultadoPrevisto { get; set; }

        public float? projetoTaxas { get; set; }

        [StringLength(10)]
        public string projetoCor { get; set; }

        public int? projeto_setorId { get; set; }

        public int? projetoGestor_entidadeId { get; set; }

        public int? projeto_statusTipoId { get; set; }

        public string projetoEntidades { get; set; }

    }
}