namespace EasyProjectG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pessoa")]
    public partial class pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pessoa()
        {
            projeto = new HashSet<projeto>();
            projetoPessoa = new HashSet<projetoPessoa>();
            tarefa = new HashSet<tarefa>();
            usuario = new HashSet<usuario>();
        }

        public int pessoaId { get; set; }

        [Required]
        [StringLength(50)]
        public string pessoaNome { get; set; }

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

        [StringLength(50)]
        public string pessoaEmail { get; set; }

        [StringLength(50)]
        public string pessoaFone { get; set; }

        [StringLength(1)]
        public string pessoaDesativado { get; set; }

        public virtual entidade entidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projeto> projeto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projetoPessoa> projetoPessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarefa> tarefa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
