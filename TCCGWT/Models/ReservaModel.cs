using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCGWT.Models
{
    public class ReservaModel
    {
        public int IdReserva { get; set; }

        public int NumPessoas { get; set; }

        public DateTime DataHoraReserva { get; set; }

        public string StatusReserva { get; set; }
        //fk
        public int IdCli { get; set; }
        //fk
        public int IdMesa { get; set; }
    }
}