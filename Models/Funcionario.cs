using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APPRH.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }  
        public string Nome { get; set; }
        [Required]
        public double Matricula { get; set; }
        public string cpf { get; set; }
        public string Setor { get; set; }
        public string Vencimento { get; set; }
        public bool Disponivel { get; set; }
    }
}