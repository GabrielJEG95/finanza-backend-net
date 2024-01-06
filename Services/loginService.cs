using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using finanza_backend_net.Models;
using finanza_backend_net.Repository;
using Microsoft.IdentityModel.Tokens;
using static finanza_backend_net.Models.dto.loginDto;

namespace finanza_backend_net.Services
{
    public interface IloginService
    {
        infoLogin login(loginUser obj);
    }
    public class loginService:IloginService
    {
        private readonly ExpenseControlContext _context;
        private readonly userRepository _repository;
        public loginService(ExpenseControlContext context)
        {
            this._context = context;
            this._repository = new userRepository(context);
        }

        public infoLogin login(loginUser obj)
        {
            validateEmptyCredential(obj.UserName,obj.password);

            var user = _context.Users.Where(w => w.UserName == obj.UserName && w.Password == obj.password)
            .FirstOrDefault();

            if(user==null)
                throw new Exception("El nombre de usuario o la contraseña son incorrectos");

            User user1 = _repository.findUserByUserName(obj.UserName);
            string token = jwtToken(user.UserName);

            infoLogin infoLogin = new infoLogin
            {
                IdUser = user1.IdUser,
                fullName = $"{user1.Name} {user1.LastName}" ,
                UserName = obj.UserName,
                Token = token
            };

            
            return infoLogin;
        }

        private void validateEmptyCredential(string UserName, string Pass)
        {
            if(UserName.IsNullOrEmpty() && !Pass.IsNullOrEmpty())
                throw new Exception("El nombre de usuario es requeridos"); 
            
            if(Pass.IsNullOrEmpty() && !UserName.IsNullOrEmpty())
                throw new Exception("La contraseña es requerida");

            if(UserName.IsNullOrEmpty() && Pass.IsNullOrEmpty())
                throw new Exception("El nombre de usuario y la contraseña son requeridos");
        }

        private static string jwtToken(string UserName)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("@finanza_gdjeg@2024"));
            var secutiyKey=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var signingCredentials=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity= new ClaimsIdentity(new[]{new Claim(ClaimTypes.Name,UserName)});

            var tokenhandler=new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenhandler.CreateJwtSecurityToken(
                subject:claimsIdentity,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:signingCredentials
                );
            var jwtTokenString = tokenhandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}