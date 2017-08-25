using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            this.LogAcessoUsuario = new List<LogAcessoUsuario>();
        }

        [Key]
        public int IdUsuario { get; set; }
        
        public int IdPerfilUsuario { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }

        public string Nome { get; set; }        
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Senha { get; set; }
        public string SenhaKey { get; set; }
        public DateTime DataCadastro { get; set; }
        public string PublicKeySocial { get; set; }
        public virtual ICollection<LogAcessoUsuario> LogAcessoUsuario { get; set; }
        
    }
}
