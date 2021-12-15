using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCGWT.Models
{
    public class ReservaCadastroModel
    {
        public int NumPessoas { get; set; }

        public DateTime DataHoraReserva { get; set; }

        public string StatusReserva { get; set; }
        //fk
        public string IdCli { get; set; }
        //fk
        public int IdMesa { get; set; }
    }
}