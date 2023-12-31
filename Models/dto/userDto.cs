using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class userDto:Paginado
    {
        public int? IdUser { get; set; }
        private string _ordenarPor{get;set;} = null!;
        public userDto()
        {
            OrdenarPor = "";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listUsers
        {
            public int IdUser {get;set;}
            public string UserName {get;set;} = null!;
            public string Status {get;set;} = null!;
        }

        public class saveUser
        {
            public string UserName {get;set;} = null!;
            public string Password {get;set;} = null!;
        }
    }
}