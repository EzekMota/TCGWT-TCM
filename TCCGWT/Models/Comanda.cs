using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCGWT.Models
{
    public class Comanda
    {
        public int IdComanda { get; set; }
        //fk
        public int IdFunc { get; set; }
        //fk
        public int IdPedido { get; set; }
        //fk
        public int IdMesa { get; set; }
    }
}