using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcSample.Models
{
    public class User
    {
        public User()
        {
            this.CreationDate = DateTime.Now;
        }

        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage="Campo User Name e Obrigatorio")]
        public String UserName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Campo Nome e Obrigatorio")]
        public String Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Campo Email e Obrigatorio")]
        public String Email
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


        public DateTime CreationDate
        {
            get;
            set;
        }
    }
}