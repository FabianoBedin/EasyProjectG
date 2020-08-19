using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyProjectG.ViewModel
{
    public class projetoPessoaViewModel
    {

        [Required]
        [StringLength(50)]
        public string entidadeSigla { get; set; }

        [StringLength(50)]
        public string entidadeCor { get; set; }

        [StringLength(50)]
        public string funcaoDescricao { get; set; }

        [StringLength(50)]
        public float? projetoPessoaQtdeSemana { get; set; }

        [StringLength(50)]
        public float? projetoPessoaCustoHora { get; set; }

        [StringLength(50)]
        public float? projetoPessoaQtdeHoraSemanal { get; set; }

        public int pessoaId { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaNome { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaFone { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaLinkLattes { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaEspecialidade { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaFormacao { get; set; }

        [StringLength(50)]
        public string pessoaFoto { get; set; }

        public int pessoa_entidadeId { get; set; }

    }
}