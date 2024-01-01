using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using finanza_backend_net.Repository;
using static finanza_backend_net.Models.dto.userDto;
using static finanza_backend_net.Models.dto.userInformationDto;

namespace finanza_backend_net.Services
{
    public interface IuserService
    {
        PaginaCollection<listUsers> userList(userDto param);
        Task createUser(saveUser obj);
        Task updateUser(int IdUser, UpdateUser obj);
    }
   
    public class userService:IuserService
    {
        private readonly ExpenseControlContext _context;
        private readonly userRepository _repository;
        public userService(ExpenseControlContext context)
        {
            this._context = context;
            this._repository = new userRepository(context);
        }

        public PaginaCollection<listUsers> userList(userDto param)
        {
            var result = _context.Users.Where(w => 
            (param.IdUser.IsNullOrDefault()|| w.IdUser == param.IdUser)
            ).Select(s1 => new listUsers
            {
                IdUser = s1.IdUser,
                UserName = s1.UserName,
                Name = s1.Name,
                LastName = s1.LastName,
                Status = s1.Status== true ? "Activo" : "Inactivo",
                listUserInformation = s1.UserInformations.Where(w2 => w2.IdUser == s1.IdUser)
                .Select(s => new listUserInformation
                {
                    Email = s.Email,
                    PhoneCode = s.PhoneCode,
                    PhoneNumber = s.PhoneNumber,
                    BirthDays = s.BirthDays
                }).ToList()
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }

        public async Task createUser(saveUser obj)
        {
            User user = Mapper<saveUser,User>.Map(obj);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task updateUser(int IdUser, UpdateUser obj)
        {
            User user = _repository.findUserById(IdUser);
            if(user == null)
                throw new Exception("No se encontro el usuario solicitado");

            user = userUpdate.Map(user,obj);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }
    }
}