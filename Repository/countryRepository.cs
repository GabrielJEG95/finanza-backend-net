using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finanza_backend_net.Models;
using static finanza_backend_net.Models.dto.countryDto;

namespace finanza_backend_net.Repository
{
    public class countryRepository
    {
        private readonly ExpenseControlContext _context;
        
        public countryRepository(ExpenseControlContext context)
        {
            this._context = context;
        }

        public bool countryExist(int IdCountry)
        {
            Country country = _context.Countries.Find(IdCountry);

            if(country == null)
                return false;
            return true;
        }

        public listCountry findCountry(int IdCountry)
        {
            var data = _context.Countries.Where(w => w.IdCountry == IdCountry)
            .Select(s => new listCountry
            {
                IdCountry = s.IdCountry,
                Country =s.Country1,
                Icon = s.Icon
            }).FirstOrDefault();

            return data;
        }
    }
}