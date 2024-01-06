using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using static finanza_backend_net.Models.dto.accountDto;
using Common.Extensions;
using Common.Paginado;
using Common.Util;

namespace finanza_backend_net.Services
{
    public interface IaccountService
    {
        PaginaCollection<listAccount> accountList(accountDto param);
        Task createAccount(saveAccount obj);
    }

    public class accountService:IaccountService
    {
        private readonly ExpenseControlContext _context;
        public accountService(ExpenseControlContext context)
        {
            this._context = context;
        }

        public PaginaCollection<listAccount> accountList(accountDto param)
        {
            var data = _context.Accounts.Where(w => 
            (param.IdAccount.IsNullOrDefault() || w.IdAccount == param.IdAccount) && 
            (param.IdUser.IsNullOrDefault() || w.IdUser == param.IdUser)
            ).Select(s => new listAccount
            {
                IdAccount = s.IdAccount,
                Account = s.Account1,
                Balance = s.Balance,
                Bank = s.IdBankNavigation.Bank1,
                Money = s.IdMoneyNavigation.Money1,
                Symbol = s.IdMoneyNavigation.Symbol,
                iconPathBank = s.IdBankNavigation.IconPath,
                colorBank = s.IdBankNavigation.Color
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task createAccount(saveAccount obj)
        {
            Account account = Mapper<saveAccount,Account>.Map(obj);

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}