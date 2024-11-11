using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinasJc.Model
{
    public class Ponto
    {
        [Key]
        public int PontoID { get; set; }

        public int UsuarioOrigemID { get; set; }
        [ForeignKey(nameof(UsuarioOrigemID))]
        public Usuario? UsuarioOrigem { get; set; }  // Chave estrangeira para Usuario (Origem)

        public int UsuarioDestinoID { get; set; }
        [ForeignKey(nameof(UsuarioDestinoID))]
        public Usuario? UsuarioDestino { get; set; }  // Chave estrangeira para Usuario (Destino)

        public int Quantidade { get; set; }
        public DateTime DataTransferencia { get; set; }
    }

}
