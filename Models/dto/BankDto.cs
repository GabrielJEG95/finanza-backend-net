using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class BankDto:Paginado
    {
        public int? IdBank {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public BankDto()
        {
            OrdenarPor = "IdBank";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }
    }
}