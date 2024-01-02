using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class accountModeDto:Paginado
    {
        public int? IdAccountMode {get;set;}
        public string? AccountMode {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public accountModeDto()
        {
            OrdenarPor = "IdAccountMode";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listAccountMode
        {
            public int IdAccountMode {get;set;}
            public string AccountMode {get;set;}
        }

        public class saveAccountMode 
        {
            public string AccountMode1 {get;set;}
        }
    }
}