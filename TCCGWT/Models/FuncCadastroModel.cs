using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCGWT.Models
{
    public class FuncCadastroModel
    {
        public string NomeFunc { get; set; }

        public string EmailFunc { get; set; }

        public string UserFunc { get; set; }

        public string SenhaFunc { get; set; }

        public string TelFunc { get; set; }

        public int NivelAcesso { get; set; }
    }
}