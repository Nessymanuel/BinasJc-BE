using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BinasJc.Model
{

    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey(nameof(UsuarioID))]
        public Usuario? Usuario { get; set; }  // Chave estrangeira para Usuario

        public int BicicletaID { get; set; }
        [ForeignKey(nameof(BicicletaID))]
        public Bicicleta? Bicicleta { get; set; }  // Chave estrangeira para Bicicleta

        public int EstacaoRetiradaID { get; set; }
        [ForeignKey(nameof(EstacaoRetiradaID))]
        public Estacao? EstacaoRetirada { get; set; }  // Chave estrangeira para Estacao (Retirada)

        public int EstacaoDevolucaoID { get; set; }
        [ForeignKey(nameof(EstacaoDevolucaoID))]
        public Estacao? EstacaoDevolucao { get; set; }  // Chave estrangeira para Estacao (Devolução)

        public DateTime DataHoraRetirada { get; set; }
        public DateTime DataHoraDevolucao { get; set; }
        public decimal DistanciaPercorrida { get; set; }
        public int PontosGanhos { get; set; }
    }
}
