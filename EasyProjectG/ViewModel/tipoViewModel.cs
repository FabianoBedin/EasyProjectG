using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyProjectG.ViewModel
{
    public class tipoViewModel
    {
        
        [DisplayName("Id")]
        public int tipoId { get; set; }

        [DisplayName("Nome")]
        public string tipoNome { get; set; }

        [DisplayName("Descricao")]
        public string tipoDescricao { get; set; }

        [DisplayName("Id Grupo")]
        public int? tipoGrupo_tipoId { get; set; }

        [DisplayName("Grupo")]
        public string tipoGrupo { get; set; }
 
    }
}