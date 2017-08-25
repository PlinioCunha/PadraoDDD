using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("LogAcessoUsuario")]
    public partial class LogAcessoUsuario
    {
        [Key]
        public int IdLogAcessoUsuario { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public DateTime DataCadastro { get; set; }
        public string IP { get; set; }
    }
}
