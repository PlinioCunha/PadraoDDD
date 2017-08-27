using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("LogSystem")]
    public class LogSystem
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(255)]
        public string Thread { get; set; }

        [MaxLength(50)]
        public string Level { get; set; }

        [MaxLength(255)]
        public string Logger { get; set; }
        
        [MaxLength(5000)]
        public string Message { get; set; }

        [MaxLength(5000)]
        public string Exception { get; set; }
    }    

}

