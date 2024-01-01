using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using finanza_backend_net.Models;

namespace finanza_backend_net.Repository
{
    public class userInformationRepository
    {
        private readonly ExpenseControlContext _context;
        public userInformationRepository(ExpenseControlContext context)
        {
            this._context = context;
        }

        public UserInformation userInformation(int IdUser)
        {
            var data = _context.UserInformations.FirstOrDefault(f => f.IdUser == IdUser);

            return data != null ? data : null;
        }

        public bool validateExistEmail(string? Email)
        {
            if (Email.IsNullOrEmpty())
                return false;

            var data = _context.UserInformations.FirstOrDefault(f => f.Email.Contains(Email));

            if(data != null)
                return true;
            return false;
        }

        public bool validateExistPhone(int? PhoneNumber)
        {
            if(PhoneNumber.IsNullOrDefault())
                return false;
                
            var data = _context.UserInformations.FirstOrDefault(f => f.PhoneNumber == PhoneNumber);
            if(data != null)
                return true;
            return false;
        }
    }
}