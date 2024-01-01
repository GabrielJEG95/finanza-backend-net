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
using static finanza_backend_net.Models.dto.userInformationDto;

namespace finanza_backend_net.Services
{
    public interface IuserInformationService
    {
        List<listUserInformation> userInfoList(userInformationDto param);
        Task userInfoSave(saveUserInfo obj);
    }

    public class userInformationService:IuserInformationService
    {
        private readonly ExpenseControlContext _context;
        private readonly userInformationRepository _repository;
        private readonly userRepository _userRepository;
        public userInformationService(ExpenseControlContext context)
        {
            this._context = context;
            this._repository = new userInformationRepository(context);
            this._userRepository = new userRepository(context);
        }

        public List<listUserInformation> userInfoList(userInformationDto param)
        {
            var data = _context.UserInformations.Where(w => 
            (param.IdUser.IsNullOrDefault() || w.IdUser == param.IdUser)
            ).Select(s => new listUserInformation
            {
                PhoneCode = s.PhoneCode,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                BirthDays = s.BirthDays
            }).ToList();

            return data;
        }

        public async Task userInfoSave(saveUserInfo obj)
        {
            bool emailExist = _repository.validateExistEmail(obj.Email);
            bool phoneExist = _repository.validateExistPhone(obj.PhoneNumber);
            User user = _userRepository.findUserById(obj.IdUser);
            

            if(user == null)
                throw new Exception("El usuario no existe");

            validate(emailExist, phoneExist);

            UserInformation userInformation = Mapper<saveUserInfo, UserInformation>.Map(obj);
            await _context.UserInformations.AddAsync(userInformation);
            await _context.SaveChangesAsync();
            
        }

        private void validate(bool email, bool phone)
        {
            if(email)
                throw new Exception("El email ingresado ya existe");

            if(phone)
                throw new Exception("El numero de telefono ingresado ya existe");
        }
    }
}