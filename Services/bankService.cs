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
using static finanza_backend_net.Models.dto.BankDto;

namespace finanza_backend_net.Services
{
    public interface IbankService
    {
        PaginaCollection<listBank> bankList(BankDto param);
        Task craeteBank(saveBank obj);
    }

    public class bankService:IbankService
    {
        private readonly ExpenseControlContext _context;
        private readonly countryRepository _repository;
        public bankService(ExpenseControlContext context)
        {
            this._context = context;
            this._repository = new countryRepository(context);
        }

        public PaginaCollection<listBank> bankList(BankDto param)
        {
            var data = _context.Banks.Where(w => 
            (param.IdBank.IsNullOrDefault() || w.IdBank == param.IdBank)
            ).Select(s => new listBank
            {
                IdBank = s.IdBank,
                Bank = s.Bank1,
                Country = s.IdCountryNavigation.Country1
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task craeteBank(saveBank obj)
        {
            bool existCountry = _repository.countryExist(obj.IdCountry);

            if(!existCountry)
                throw new Exception("El país seleccionado no existe");

            Bank bank = Mapper<saveBank,Bank>.Map(obj);
            await _context.Banks.AddAsync(bank);
            await _context.SaveChangesAsync();
        }
    }
}