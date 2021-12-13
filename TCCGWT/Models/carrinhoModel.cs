using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCGWT.Models
{
    public class carrinhoModel
    {
        public int IdCarrinho { get; set; }

        public string CepCarrinho { get; set; }

        public string LogradouroCarrinho { get; set; }

        public int NumCarrinho { get; set; }

        public string ComplementoCarrinho { get; set; }
        //fk
        public int IdPedido { get; set; }
        //fk
        public int IdCli { get; set; }
    }
}