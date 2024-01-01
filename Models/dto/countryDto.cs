using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class countryDto:Paginado
    {
        public int? IdCountry {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public countryDto()
        {
            OrdenarPor = "IdCountry";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listCountry
        {
            public int IdCountry {get;set;}
            public string Country {get;set;}
            public string? Icon {get;set;}
        }

        public class saveCoutry
        {
            public string Country {get;set;}
            public string? Icon {get;set;}
        }
    }
}