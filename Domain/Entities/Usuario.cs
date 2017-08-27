using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [JsonIgnore]
        public virtual PerfilUsuario PerfilUsuario { get; set; }

        public string Nome { get; set; }        
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Senha { get; set; }
        public string SenhaKey { get; set; }

        //[DefaultValue(typeof(DateTime), DateTime.Now.ToString)]
        public DateTime DataCadastro { get; set; }

        public string PublicKeySocial { get; set; }

        [JsonIgnore]
        public virtual ICollection<LogAcessoUsuario> LogAcessoUsuario { get; set; }
        
    }
}
