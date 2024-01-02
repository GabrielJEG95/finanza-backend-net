using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Paginado;
using Common.Util;
using finanza_backend_net.Models;
using finanza_backend_net.Models.dto;
using static finanza_backend_net.Models.dto.accountModeDto;

namespace finanza_backend_net.Services
{
    public interface IaccountModeService
    {
        PaginaCollection<listAccountMode> accountModeList(accountModeDto param);
        Task createAccountMode(saveAccountMode obj);
    }
    public class accountModeService:IaccountModeService
    {
        private readonly ExpenseControlContext _context;
        public accountModeService(ExpenseControlContext context)
        {
            this._context = context;
        }

        public PaginaCollection<listAccountMode> accountModeList(accountModeDto param)
        {
            var data = _context.AccountModes.Where(w => 
            (param.IdAccountMode.IsNullOrDefault() || w.IdAccountMode == param.IdAccountMode) && 
            (param.AccountMode.IsNullOrEmpty()|| w.AccountMode1.ToUpper().Contains(param.AccountMode.ToUpper()))
            ).Select(s => new listAccountMode
            {
                IdAccountMode = s.IdAccountMode,
                AccountMode = s.AccountMode1
            }).Paginar(param.pagina,param.registroPorPagina);

            return data;
        }

        public async Task createAccountMode(saveAccountMode obj)
        {
            AccountMode accountMode = Mapper<saveAccountMode,AccountMode>.Map(obj);
            await _context.AccountModes.AddAsync(accountMode);
            await _context.SaveChangesAsync();
        }
    }
}