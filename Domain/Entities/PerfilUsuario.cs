using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{    
    public partial class PerfilUsuario
    {
        public PerfilUsuario()
        {
            this.ModulosAcesso = new List<ModulosAcesso>();
            this.Usuarios = new List<Usuario>();
        }

        [Key]
        public int IdPerfilUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomePerfil { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ModulosAcesso> ModulosAcesso { get; set; }
    }
}
