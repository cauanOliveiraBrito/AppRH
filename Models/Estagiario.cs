using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APPRH.Models
{
    public class Estagiario
    {
        public int estagiarioid { get; set; }

        public string nome { get; set; }
        [Required]

        public int idade { get; set; }

        public string cpf { get; set; }

        public string cargo { get; set; }

        public int matricula { get; set; }
    }
}