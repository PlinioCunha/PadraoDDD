using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class ModulosAcesso
    {
        public ModulosAcesso()
        {
            this.PerfisUsuario = new List<PerfilUsuario>();
        }

        [ForeignKey("ModuloAcesso")]
        public int IdModulosAcesso { get; set; }
        public virtual ModulosAcesso ModuloAcesso { get; set; }

        public string NomeModulo { get; set; }
        public string NomeMenuAcesso { get; set; }
        public string UrlMenu { get; set; }
        public bool Ativo { get; set; }
        public bool Visualizar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? IdModuloPai { get; set; }
        
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }


    }
}