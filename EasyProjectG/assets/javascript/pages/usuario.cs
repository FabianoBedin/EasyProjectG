namespace EasyProjectG.assets.javascript.pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            nota = new HashSet<nota>();
            tarefa = new HashSet<tarefa>();
        }

        public int usuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string usuarioEmail { get; set; }

        [Required]
        [StringLength(12)]
        public string usuarioSenha { get; set; }

        public int usuario_nucleoId { get; set; }

        public int? usuarioNivel_tipoId { get; set; }

        public int? usuario_pessoaId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nota> nota { get; set; }

        public virtual nucleo nucleo { get; set; }

        public virtual pessoa pessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarefa> tarefa { get; set; }

        public virtual tipo tipo { get; set; }
    }
}
