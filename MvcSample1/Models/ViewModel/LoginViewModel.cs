using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSample.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo User Name e Obrigatorio")]
        public String UserName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Campo Senha e Obrigatorio")]
        public String Password
        {
            get;
            set;
        }
    }
}