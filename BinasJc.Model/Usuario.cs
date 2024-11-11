using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinasJc.Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public int PontuacaoTotal { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
