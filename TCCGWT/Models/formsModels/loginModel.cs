using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TCCGWT.Models.formsModels
{
    public class loginModel
    {
        [Required(ErrorMessage = "O campo usuário não pode ser nulo")]
        public string userCli { get; set; }

        [Required(ErrorMessage = "O campo senha não pode ser nulo")]
        public string senhaCli { get; set; }
    }
}