using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace finanza_backend_net.Models.dto
{
    public class loginDto
    {
        public class loginUser
        {
            [Required (ErrorMessage="El nombre de usuario es requerido")]
            public string UserName {get;set;}

            [Required (ErrorMessage="La contraseña es requerida")]
            public string password{get;set;}
        }

        public class infoLogin
        {
            public int IdUser {get;set;}
            public string fullName {get;set;}
            public string UserName {get;set;}
            public string Token {get;set;}
        }
        public class GetToken
        {
            public string accessToken {get;set;}
        }
    }
}