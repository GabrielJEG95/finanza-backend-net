using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finanza_backend_net.Models;

namespace finanza_backend_net.Repository
{
    public class userRepository
    {
        private readonly ExpenseControlContext _context;

        public userRepository(ExpenseControlContext context)
        {
            this._context = context;
        }

        public User findUserById(int IdUser)
        {
            var data = _context.Users.Find(IdUser);

            return data == null ? null : data;
        }
    }
}