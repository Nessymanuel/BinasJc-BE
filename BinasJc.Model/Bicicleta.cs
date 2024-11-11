using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinasJc.Model
{
    public class Bicicleta
    {
        [Key]
        public int BicicletaID { get; set; }
        public string Status { get; set; }
        public string BeaconID { get; set; }

        // Relação com a Estação
        
        public int EstacaoID { get; set; }
        [ForeignKey(nameof(EstacaoID))]
        public Estacao ? Estacao { get; set; }

        
    }

}
