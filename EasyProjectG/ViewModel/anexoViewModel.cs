using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyProjectG.ViewModel
{
    public class anexoViewModel
    {
        
         [DisplayName("Nome")]
        public string anexoNome { get; set; }

        [DisplayName("tipo")]
        public string anexoTipo { get; set; }

        [DisplayName("DAta")]
        public DateTime? anexoDataCriacao { get; set; }

        [DisplayName("Usuario")]
        public string anexoUsuario { get; set; }

        [DisplayName("DAta")]
        public DateTime? anexoDataAlteracao { get; set; }

    }
}