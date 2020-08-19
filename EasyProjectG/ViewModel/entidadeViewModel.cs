using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyProjectG.ViewModel
{
    public class entidadeViewModel
    {
        
        [DisplayName("Id")]
        public int entidadeId { get; set; }
        [Required]
        [StringLength(80)]
        public string entidadeRazaoSocial { get; set; }

        [StringLength(10)]
        public string entidadeSigla { get; set; }

        [StringLength(20)]
        public string entidadeFone { get; set; }

        [StringLength(50)]
        public string entidadeSite { get; set; }

        [StringLength(50)]
        public string entidadeCidade { get; set; }

        [StringLength(50)]
        public string entidadeFacebook { get; set; }

        [StringLength(10)]
        public string entidadeCor { get; set; }

        [StringLength(50)]
        public string entidadeBairro { get; set; }

        [StringLength(50)]
        public string entidadePais { get; set; }

        [StringLength(50)]
        public string entidadeLogradouro { get; set; }

        [StringLength(10)]
        public string entidadeCEP { get; set; }

        [StringLength(1)]
        public string entidadeLetra { get; set; }

        [StringLength(50)]
        public string entidadeWhatsapp { get; set; }

        public int entidade_nucleoId { get; set; }

        public int entidade_tipoId { get; set; }

    }
}