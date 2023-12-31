using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using static finanza_backend_net.Models.dto.userDto;

namespace finanza_backend_net.Services
{
    public interface IuserService
    {
        PaginaCollection<listUsers> userList(userDto param);
        Task createUser(saveUser obj);
    }
   
    public class userService:IuserService
    {
        private readonly ExpenseControlContext _context;
        public userService(ExpenseControlContext context)
        {
            this._context = context;
        }

        public PaginaCollection<listUsers> userList(userDto param)
        {
            var result = _context.Users.Where(w => 
            (param.IdUser.IsNullOrDefault()|| w.IdUser == param.IdUser)
            ).Select(s => new listUsers
            {
                IdUser = s.IdUser,
                UserName = s.UserName,
                Status = s.Status== true ? "Activo" : "Inactivo"
            }).Paginar(param.pagina,param.registroPorPagina);

            return result;
        }

        public async Task createUser(saveUser obj)
        {
            User user = Mapper<saveUser,User>.Map(obj);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}