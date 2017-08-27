<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
=======
﻿using System;
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Tarefa")]
    public class Tarefa
    {

        public Tarefa()
        {
            this.HistoricoTarefa = new List<HistoricoTarefa>();
        }

        [Key]
        public int IdTarefa { get; set; }

        [Required]
        public string TituloTarefa { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; } 


        public int IdCategoriaTarefa { get; set; }
        public string Descricao { get; set; }


        [ForeignKey("UsuarioCreate")]
        public int IdUsuarioCreate { get; set; }
<<<<<<< HEAD

        [JsonIgnore]
        public virtual Usuario UsuarioCreate { get; set; }
        

        [ForeignKey("HistoricoTarefa")]
        public int IdHistoricoTarefa { get; set; }

        [JsonIgnore]
=======
        public virtual Usuario UsuarioCreate { get; set; }

        [ForeignKey("HistoricoTarefa")]
        public int IdHistoricoTarefa { get; set; }
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
        public virtual ICollection<HistoricoTarefa> HistoricoTarefa { get; set; }

    }

    [Table("HistoricoTarefa")]
    public class HistoricoTarefa
    {
        [Key]
        public int IdHistoricoTarefa { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Tarefa")]
        public int IdTarefa {get;set;}
<<<<<<< HEAD

        [JsonIgnore]
=======
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
        public virtual Tarefa Tarefa { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
<<<<<<< HEAD

        [JsonIgnore]
=======
>>>>>>> bda26d952f67ba685a8e18ac1b7add367b4885ca
        public virtual Usuario Usuario { get; set; }

        [Required]
        public string TextoHistorico { get; set; }
    }


}

