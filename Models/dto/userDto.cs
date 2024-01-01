using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Paginado;
using static finanza_backend_net.Models.dto.userInformationDto;

namespace finanza_backend_net.Models.dto
{
    public class userDto:Paginado
    {
        public int? IdUser { get; set; }
        private string _ordenarPor{get;set;} = null!;
        public userDto()
        {
            OrdenarPor = "IdUser";
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
            public string Name {get;set;} = null!;
            public string LastName {get;set;} = null!;
            public string Status {get;set;} = null!;
            public List<listUserInformation> listUserInformation {get;set;}
        }

        public class saveUser
        {
            public string Name {get;set;} = null!;
            public string LastName {get;set;} = null!;
            public string UserName {get;set;} = null!;
            public string Password {get;set;} = null!;
        }

         public class UpdateUser
        {
            public string Password {get;set;} = null!;
        }

        public partial class userUpdate
        {
            public static User Map(User original,UpdateUser upt)
            {
                original.Password=upt.Password;
                return original;
            }
        }
    }
}