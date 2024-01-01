using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class moneyDto:Paginado
    {
        public int? IdMoney {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public moneyDto()
        {
            OrdenarPor = "IdMoney";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listMoney
        {
            public int IdMoney {get;set;}
            public string Money1 {get;set;}
            public string Symbol {get;set;}
        }

        public class saveMoney
        {
            public string Money1 {get;set;}
            public string Symbol {get;set;}
        }
    }
}