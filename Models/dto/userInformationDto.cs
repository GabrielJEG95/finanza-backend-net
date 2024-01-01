using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Paginado;

namespace finanza_backend_net.Models.dto
{
    public class userInformationDto:Paginado
    {
        public int? IdUser {get;set;}
        private string _ordenarPor{get;set;} = null!;
        public userInformationDto()
        {
            OrdenarPor = "IdUserInformation";
            OrientarPor = "asc";
        }

        public new string OrdenarPor
        {
            get {return _ordenarPor;}
            set {_ordenarPor =value;}
        }

        public class listUserInformation
        {
            public string? Email { get; set; }

            public int? PhoneCode { get; set; }

            public int? PhoneNumber { get; set; }

            public DateTime? BirthDays { get; set; }
        }

        public class saveUserInfo
        {
            public int IdUser {get;set;}
            public string? Email { get; set; }

            public int? PhoneCode { get; set; }

            public int? PhoneNumber { get; set; }

            public DateTime? BirthDays { get; set; }
        }
    }
}