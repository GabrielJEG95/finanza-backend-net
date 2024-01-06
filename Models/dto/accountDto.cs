using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class accountDto:Paginado
    {
        public int? IdAccount {get;set;}
        public int? IdUser {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public accountDto()
        {
            OrdenarPor = "IdAccount";
            OrientarPor = "asc";
        }
        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listAccount
        {
            public int IdAccount {get;set;}
            public string Account {get;set;}
            public decimal? Balance {get;set;}
            public string Bank {get;set;}
            public string iconPathBank {get;set;}
            public string colorBank {get;set;}
            public string Money {get;set;}
            public string Symbol {get;set;}
        }

        public class saveAccount 
        {
            public string Account1 {get;set;}
            public decimal Balance {get;set;}
            public int IdMoney {get;set;}
            public int IdUser {get;set;}
            public int IdBank {get;set;}
            public int IdAccountMode {get;set;}
            public int IdAccountType {get;set;}
        }
    }
}