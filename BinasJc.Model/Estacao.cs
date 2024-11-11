using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinasJc.Model
{
    public class Estacao
    {
        [Key]
        public int EstacaoID { get; set; }
        public string NomeEstacao { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int BicicletasDisponiveis { get; set; }
    }

}
